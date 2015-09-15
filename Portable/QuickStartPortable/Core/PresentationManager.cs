using System;
using System.Text;

namespace QuickStart
{

    public abstract class PresentationManager
    {
        public event EventHandler BeforeShowingView;
        public event EventHandler AfterShowingView;

		public void ShowView(AppView view)
        {
            OnBeforeShowingView(view);
            DoShowView(view);
            OnAfterShowingView(view);
        }


		public abstract void GoBack();

		protected abstract void DoShowView(AppView view);

		private void OnAfterShowingView(AppView view)
        {
            EventHandler handler = AfterShowingView;

            handler?.Invoke(this, EventArgs.Empty);
        }

		private void OnBeforeShowingView(AppView view)
        {
            EventHandler handler = BeforeShowingView;

            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}
