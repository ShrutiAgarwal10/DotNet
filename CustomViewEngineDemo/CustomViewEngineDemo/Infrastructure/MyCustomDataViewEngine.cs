using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomViewEngineDemo.Infrastructure
{
    public class MyCustomDataViewEngine : IViewEngine
    {
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return new ViewEngineResult(new string[]
                {"No view(My Custom Data View Engine)" });
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if(viewName=="MyCustomData")
            {
                return new ViewEngineResult(new MyCustomDataView(), this);
            }
            else
            {
                return new ViewEngineResult(new string[]
                {
                    "No view (My Custom Data View Engine)" });
            }
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
            throw new NotImplementedException();
        }
    }
}