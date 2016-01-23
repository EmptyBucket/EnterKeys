using GalaSoft.MvvmLight.Views;

namespace EnterKeyes.Model.NavigationService
{
    public interface IModernNavigationService : INavigationService
    {
        /// <summary>  
        /// Gets the parameter.  
        /// </summary>  
        /// <value>  
        /// The parameter.  
        /// </value>  
        object Parameter { get; }
    }
}
