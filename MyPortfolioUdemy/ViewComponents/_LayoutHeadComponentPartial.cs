using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _LayoutHeadComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
