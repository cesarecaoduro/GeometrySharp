﻿using System.Collections.Generic;
using GeometrySharp.Geometry;
using GeometrySharp.Operation;

namespace GeometrySharp.Optimization
{
    /// <summary>
    /// Minimizer functions collects the basic functions used into the minimization process,
    /// to define the intersection results between curves.
    /// </summary>
    public class MinimizerFunctions
    {
        private readonly NurbsCurve _curve0;
        private readonly NurbsCurve _curve1;

        /// <summary>
        /// Initialize the class, which collects the functions used for the minimization problem.
        /// </summary>
        /// <param name="curve0">First curve used in the intersection process.</param>
        /// <param name="curve1">First curve used in the intersection process.</param>
        public MinimizerFunctions(NurbsCurve curve0, NurbsCurve curve1)
        {
            _curve0 = curve0;
            _curve1 = curve1;
        }

        /// <summary>
        /// Gets the objective function.
        /// </summary>
        public double Objective(Vector3 v)
        {
            Vector3 p0 = Evaluation.CurvePointAt(_curve0, v[0]);
            Vector3 p1 = Evaluation.CurvePointAt(_curve1, v[1]);

            Vector3 p0P1 = p0 - p1;

            return Vector3.Dot(p0P1, p0P1);
        }

        /// <summary>
        /// Gets the gradient function.
        /// </summary>
        public Vector3 Gradient(Vector3 v)
        {
            List<Vector3> deriveC0 = Evaluation.RationalCurveDerivatives(_curve0, v[0], 1);
            List<Vector3> deriveC1 = Evaluation.RationalCurveDerivatives(_curve0, v[1], 1);

            Vector3 r = deriveC0[0] - deriveC1[0];
            Vector3 drDt = deriveC1[1] * -1.0;

            double value0 = 2.0 * Vector3.Dot(deriveC0[1], r);
            double value1 = 2.0 * Vector3.Dot(drDt, r);

            return new Vector3{value0, value1};
        }
    }
}
