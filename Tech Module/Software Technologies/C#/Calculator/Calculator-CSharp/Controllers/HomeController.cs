using System.Web.Mvc;
using System.Web;
using Calculator_CSharp.Models;
using System;

namespace Calculator_CSharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Calculator calculator)
        {
            return View(calculator);
        }

        [HttpPost]
        public ActionResult Calculate (Calculator calculator)
        {
            calculator.Result = calculateResult(calculator);

            return RedirectToAction("Index", calculator);
        }

        public decimal calculateResult(Calculator calculator)
        {
            decimal result = 0;

            if (calculator.Operator == "+")
            {
                result = calculator.LeftOperand + calculator.RightOperand;
            }
            else if (calculator.Operator == "-")
            {
                result = calculator.LeftOperand - calculator.RightOperand;
            }
            else if (calculator.Operator == "/")
            {
                if (calculator.RightOperand != 0)
                {
                    result = calculator.LeftOperand / calculator.RightOperand;
                }

            }
            else if (calculator.Operator == "*")
            {
                result = calculator.LeftOperand * calculator.RightOperand;
            }
            // Calculate the power of given base with given exponent!
            // The base is LeftOperand and exponent is the RightOperand!
            else if (calculator.Operator == "^")    
            {                                    
                result = (decimal)(Math.Pow((double)calculator.LeftOperand, (double)calculator.RightOperand));
            }
            // Calculate the N-th root of given base!
            // RightOperand is base and LeftOperand is the given root!
            else if (calculator.Operator == '\u221A'.ToString())    
            {                                       
                if (calculator.LeftOperand != 0)
                {
                    result = (decimal)(Math.Pow((double)calculator.RightOperand, (double)(1 / calculator.LeftOperand)));
                }
            }


            return result;
        }
    }
}