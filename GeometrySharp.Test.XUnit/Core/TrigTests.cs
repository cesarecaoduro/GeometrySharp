﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using GeometrySharp.Core;
using GeometrySharp.Geometry;
using Xunit;

namespace GeometrySharp.Test.XUnit.Core
{
    [Trait("Category", "Trig")]
    public class TrigTests
    {
        [Fact]
        public void It_Returns_True_If_Three_Points_Are_Flat()
        {
            Vector3 p1 = new Vector3() { 0.0, 0.0, 0.0 };
            Vector3 p2 = new Vector3() { 10.0, 0.0, 0.0 };
            Vector3 p3 = new Vector3() { 5.0, 5.0, 0.0 };
            Vector3 p4 = new Vector3() { -5.0, -15.0, 0.0 };
            List<Vector3> points = new List<Vector3>(){p1,p2,p3,p4};

            Trig.ArePointsCoplanar(points).Should().BeTrue();
        }
    }
}