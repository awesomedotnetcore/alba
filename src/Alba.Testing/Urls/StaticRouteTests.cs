﻿using System.Threading.Tasks;
using Alba.Routing;
using Alba.Urls;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Alba.Testing.Urls
{
    public class StaticRouteTests
    {
        private readonly StaticRoute theRoute = new StaticRoute(new Route("folder", "GET", e => Task.CompletedTask));

        [Fact]
        public void should_register_itself_as_static_route()
        {
            var graph = Substitute.For<IUrlGraph>();

            theRoute.Register(graph);

            graph.Received().Register(theRoute.Route.Name, theRoute);
        }
    }
}