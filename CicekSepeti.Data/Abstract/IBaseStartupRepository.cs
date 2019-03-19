using Common;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Data.Abstract
{
    public interface IBaseStartupRepository
    {
        IOptions<Settings> settings { get; set; }
    }
}
