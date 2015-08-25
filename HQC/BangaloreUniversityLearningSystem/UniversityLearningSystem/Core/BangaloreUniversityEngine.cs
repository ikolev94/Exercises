namespace UniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using UniversityLearningSystem.Data;
    using UniversityLearningSystem.Interfaces;
    using UniversityLearningSystem.Models;

    public class BangaloreUniversityEngine : IEngine
    {
        public void Run()
        {
             var controllerFactory = new ControllerFactory();
            var data = new BangaloreUniversityDate();
            User user = null;
            while (true)
            {
                string routeUrl = Console.ReadLine();
                if (routeUrl == null)
                {
                    break;
                }

                var route = new Route(routeUrl);
                var controllerType =
                    Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .FirstOrDefault(type => type.Name == route.ControllerName);

                var controller = controllerFactory.Create(route.ControllerName, data, user);
                var act = controllerType.GetMethod(route.ActionName);
                object[] @params = MapParameters(route, act);
                try
                {
                    var view = act.Invoke(controller, @params) as IView;
                    Console.WriteLine(view.Display());
                    user = controller.User;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            return action.GetParameters().Select<ParameterInfo, object>(
                p =>
                    {
                        if (p.ParameterType == typeof(int))
                        {
                            return int.Parse(route.Parameters[p.Name]);
                        }
                        else
                        {
                            return route.Parameters[p.Name];
                        }
                    }).ToArray();
        }
    }
}