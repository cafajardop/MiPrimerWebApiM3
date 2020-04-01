using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerWebApiM3.Helpers
{
    public class MiFiltro: IActionFilter
    {
        private readonly ILogger<MiFiltro> logger;
        public MiFiltro(ILogger<MiFiltro> logger)
        {
            this.logger = logger;
        }
        
        //Antes de la accion
        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogError("OnActionExecuting");
        }
        //Despues de la accion
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogError("OnActionExecuted");
        }
    }
}
