using System;
using System.Collections.Generic;
using System.Text;

namespace PItuning.Models.Controllers
{
    public interface ITransferFunction
    {
        double TransferFunction(double input);
    }
}
