using Ninject;

namespace EnterKeyes.ViewModel
{
    public class ViewModelLocator
    {
        private static StandardKernel Kernel = new StandardKernel(new MainModule());

        public const string OpenFilePage = "OpenFilePageKey";
        public OpenFileViewModel OpenFile { get; } = Kernel.Get<OpenFileViewModel>();

        public const string EnterKeysPageKey = "EnterKeyesPageKey";
        public EnterKeysViewModel EnterKeys { get; } = Kernel.Get<EnterKeysViewModel>();

        public static void Cleanup()
        {
        }
    }
}