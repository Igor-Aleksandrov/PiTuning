using System;
using System.Collections.Generic;
using System.Text;

namespace PItuning.Models.Controllers
{
    /// <summary>
    /// Parallel Controller Algorithm. P = Kp (Proportional Gain); I = Ki (Integral Gain); D = Kd (Derivative Time).   
    /// </summary>
    public class ControllerParallel : Controller, ITransferFunction
    {
        /// <summary>
        /// Creating PID Parallel Controller.
        /// </summary>
        /// <param name="p">Proportional Gain</param>
        /// <param name="i">Integral Gain</param>
        /// <param name="d">Derivative Time</param>
        public ControllerParallel(double p = 1, double i = 0, double d = 0)
        {
            TypeAlg = TypeAlgorithm.Noninteractive;
            TypeM = TypeRule.None;
            P = p;
            I = i;
            D = d;
        }
        // TODO TypeRule
        public ControllerParallel(TypeRule typeM, double p = 1, double i = 0, double d = 0) : this(p, i, d)
        {
            TypeM = typeM;
        }

        /// Computation out signal after controller.
        public double TransferFunction(double input)
        {
            //TODO ControllerParallel TransferFunction
            return input;
        }
    }
}
