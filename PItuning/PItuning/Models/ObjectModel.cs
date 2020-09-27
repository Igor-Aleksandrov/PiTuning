using PItuning.Models.Controllers;
using System.Collections.Generic;

namespace PItuning.Models
{
    /// <summary>
    /// Contains model's parameters. Ones describe the control object through the transfer function.
    /// The parameters are calculated experimentally by indetification or by analytical methods.
    /// The parameters of the control object are necessary for calculating the PID controler's tunning parameters of the control loop.
    /// </summary>
    public class ObjectModel
    {
        public string Id { get; set; }
        public string TagName { get; set; }
        public string Description { get; set; }

        private double dt, tau1, tau2, beta;

        public List<Controller> PiControllers { get; set; }

        /// <summary>
        /// Process gain.
        /// Gp = change in PV [in %] / change in CO [in %].
        /// </summary>
        public double Gp { get; set; }

        /// <summary>
        /// Dead time.
        /// Difference between the step-change in CO and the beginning of change PV response curve.
        /// </summary>
        public double Dt
        {
            get { return dt; }
            set
            {
                dt = (value >= 0) ? value : 1; //TODO contract programming
            }
        }

        /// <summary>
        /// Time constant.
        /// Difference between intersection at the end of dead time, and the PV reaching 63% of its total change.
        /// </summary>
        public double Tau1
        {
            get { return tau1; }
            set
            {
                tau1 = (value >= 0) ? value : 0; //TODO contract programming
            }
        }

        /// <summary>
        /// Time constant of second order.
        /// </summary>
        public double Tau2
        {
            get { return tau2; }
            set
            {
                tau2 = (value >= 0) ? value : 0; //TODO contract programming
            }
        }

        /// <summary>
        /// Time constant of second order..
        /// </summary>
        public double Beta
        {
            get { return beta; }
            set
            {
                beta = (value >= 0) ? value : 0; //TODO contract programming
            }
        }
    }

}