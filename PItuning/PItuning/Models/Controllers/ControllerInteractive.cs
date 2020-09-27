﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PItuning.Models.Controllers
{
    /// <summary>
    /// Noninteractive Controller Algorithm. P = Kc (Controller Gain); I = Ti (Integral Time); D = Td (Derivative Time).   
    /// </summary>
    public class ControllerInteractive : Controller, IGetCentumPID, ITransferFunction
    {
        /// <summary>
        /// Creating PID Interactive Controller.
        /// </summary>
        /// <param name="p">Controller Gain</param>
        /// <param name="i">Integral Time</param>
        /// <param name="d">Derivative Time</param>
        public ControllerInteractive(double p = 1, double i = 0, double d = 0)
        {
            TypeAlg = TypeAlgorithm.Noninteractive;
            TypeM = TypeRule.None;
            P = p;
            I = i;
            D = d;
        }
        // TODO TypeRule
        public ControllerInteractive(TypeRule typeM, double p = 1, double i = 0, double d = 0) : this(p, i, d)
        {
            TypeM = typeM;
        }

        /// Computation out signal after controller.
        public double TransferFunction(double input)
        {
            //TODO ControllerNoninteractive TransferFunction
            return input;
        }

        /// <summary>
        /// Converting Interactive to CentumPID Controller Algorithm.
        /// </summary>
        /// <returns>CentumPID Controller Algorithm</returns>
        public ControllerCentumPID GetControllerCentumPID()
        {
            ControllerCentumPID ctr = new ControllerCentumPID();
            ctr.P = 100 * I / (P * (I + D));
            ctr.I = I + D;
            ctr.D = I * D / (I + D);
            return ctr;
        }
    }
}
