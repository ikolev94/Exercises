namespace UniversityLearningSystem
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using UniversityLearningSystem.Interfaces;

    /// <summary>The route.</summary>
    public class Route : IRoute
    {
        /// <summary>Initializes a new instance of the <see cref="Route"/> class.</summary>
        /// <param name="routeUrl">The route url.</param>
        public Route(string routeUrl)
        {
            this.Parse(routeUrl);
        }

        /// <summary>Gets the action name.</summary>
        /// <value>The action name.</value>
        public string ActionName { get; private set; }

        /// <summary>Gets the controller name.</summary>
        /// <value>The controller name.</value>
        public string ControllerName { get; private set; }

        /// <summary>Gets the parameters.</summary>
        /// <value>The parameters.</value>
        public IDictionary<string, string> Parameters { get; private set; }

        /// <summary>The parse.</summary>
        /// <param name="routeUrl">The route url as string.</param>
        /// <exception cref="ArgumentException">If the route url is invalid</exception>
        private void Parse(string routeUrl)
        {
            string[] parts = routeUrl.Split(new[] { "/", "?" }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
            {
                throw new ArgumentException("The provided route is invalid.");
            }

            this.ControllerName = parts[0] + "Controller";
            this.ActionName = parts[1];
            if (parts.Length >= 3)
            {
                this.Parameters = new Dictionary<string, string>();
                string[] parameterPairs = parts[2].Split('&');
                foreach (var pair in parameterPairs)
                {
                    string[] nameValue = pair.Split('=');
                    this.Parameters.Add(WebUtility.UrlDecode(nameValue[0]), WebUtility.UrlDecode(nameValue[1]));
                }
            }
        }
    }
}