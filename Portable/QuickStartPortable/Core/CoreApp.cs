using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace QuickStart
{
	public class CoreApp
	{
		public static CoreApp SharedApp {
			get;
			set;
		}

		private CancellationTokenSource tokenSource = new CancellationTokenSource();
		private int loopdelay;

		public AppState State {
			get;
			set;
		}

		public IPhotoProvider PhotoProvider {
			get;
			set;
		}

		public PresentationManager PresentationManager {
			get;
			set;
		}

		private readonly Stack<PhotoCommand> PhotoCommands;
		private Task _activePhotoTask;

		public CoreApp (int frequency, AppState state)
		{
			loopdelay = frequency;
			State = state;
			PhotoCommands = new Stack<PhotoCommand> ();
		}

		public CancellationToken Start(){
			Task.Factory.StartNew (delegate() {
				UpdateLoop(tokenSource.Token);
			});
			return tokenSource.Token;
		}

		public void Stop(){
			tokenSource.Cancel ();
		}

		public void LoadInterestingPhotos(){
			PhotoCommands.Push (new PhotoCommand (){ Action = PhotoCommand.PhotoAction.Get, Source = new PhotoSource(){Source = PhotoSource.SourceType.Interesting}});
		}

		private async void UpdateLoop(CancellationToken token){
			long timePassed = 0;
			long timestamp = DateTime.Now.Ticks;
			while (!token.IsCancellationRequested) {
				Update (timePassed);
				await Task.Delay (loopdelay);
				timePassed = Convert.ToInt64(TimeSpan.FromTicks (DateTime.Now.Ticks - timestamp).TotalMilliseconds);
				timestamp = DateTime.Now.Ticks;
			}
		}

		private void Update(long timePassed){
			//Core loop for logic
			if(_activePhotoTask == null && PhotoCommands.Count > 0){
				var command = PhotoCommands.Pop ();
				var action = CreatePhotoAction (command);
				if(action != null)
				_activePhotoTask = Task.Factory.StartNew(action);
			}
			if(_activePhotoTask != null){
				if (_activePhotoTask.IsCompleted) {

					if (_activePhotoTask.IsFaulted) {
						System.Diagnostics.Debug.WriteLine (_activePhotoTask.Exception.Message);
						foreach (var ex in _activePhotoTask.Exception.InnerExceptions) {
							System.Diagnostics.Debug.WriteLine (ex.Message);							
						}
					}
					_activePhotoTask = null;
				}
			}
		}

		private Action CreatePhotoAction(PhotoCommand command){
			if (command.Source.Source == PhotoSource.SourceType.Interesting) {
				return new Action(()=>{
					State.CurrentPhotos.Clear();
					foreach (var item in PhotoProvider.GetInteresting()){
						State.CurrentPhotos.Add(item);
					}
				});
			}
			return null;
		}
	}

	public struct PhotoCommand{
		public enum PhotoAction
		{
			Get
		}

		public PhotoAction Action {
			get;
			set;
		}


		public PhotoSource Source {
			get;
			set;
		}	
	}
}

