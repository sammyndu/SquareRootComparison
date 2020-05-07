using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SquareRootComparison.Models;

namespace SquareRootComparison.Controllers
{
    public class SquareController : Controller
    {
        private readonly ILogger<SquareController> _logger;

        public SquareController(ILogger<SquareController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SquareNumbers SquareNumbersModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.StatusKey = "danger";
                ViewBag.StatusMessage = "Only Numbers Greater Zero(0) are allowed";
            }
            else
            {
                var firstNumber = SquareNumbersModel.FirstSquareNumber;
                var secondNumber = SquareNumbersModel.SecondSquareNumber;
                var squareRootOfFirstNumber = Math.Sqrt(firstNumber);
                var squareRootOfSecondNumber = Math.Sqrt(secondNumber);

                if (Math.Sqrt(squareRootOfFirstNumber) > Math.Sqrt(squareRootOfSecondNumber))
                {
                    ViewBag.StatusKey = "success";
                    ViewBag.StatusMessage = $"The number {firstNumber} " +
                        $"with square root of {squareRootOfFirstNumber} is greater than the number {secondNumber} with square root of {squareRootOfSecondNumber}";
                }
                else if (Math.Sqrt(SquareNumbersModel.FirstSquareNumber) == Math.Sqrt(SquareNumbersModel.SecondSquareNumber))
                {
                    ViewBag.StatusKey = "warning";
                    ViewBag.StatusMessage = "The number numbers provided are " +
                        "the same and have the same square root, Please provide another number";
                }
                else
                {
                    ViewBag.StatusKey = "success";
                    ViewBag.StatusMessage = $"The number {secondNumber} " +
                        $"with square root of {squareRootOfSecondNumber} is greater than the number {firstNumber} with square root of {squareRootOfFirstNumber}";
                }
            }
            return View(SquareNumbersModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
