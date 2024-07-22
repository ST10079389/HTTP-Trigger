using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
namespace ST10079389_AwehProd_HTTPTrigger
{
    public static class Vaccination
    {
        [FunctionName("ID")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "id/{id?}")] HttpRequest req,
            string id,
            ILogger log)
        {
            log.LogInformation("Vaccinaton Information requested.");
            //string id = req.Query["id"];
            //the trigger will request for the id number
            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //id = id ?? data?.id;
            try
            {
                long yearInt;
                if (long.TryParse(id, out yearInt))
                {
                    string responseMessage = GenerateVaccinationMessage(yearInt);
                    return new OkObjectResult(responseMessage);
                }
                else
                {
                    string responseMessage = "Welcome to Rush Hour 2 Vaccine Health Care! Please enter your ID number using the 'id' " +
                        "query parameter. Kindly follow the example. E.g /id/0203171934890";
                    return new OkObjectResult(responseMessage);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred. Please check your ID number or URL is valid.";
                log.LogError(ex, errorMessage);
                return new BadRequestObjectResult(errorMessage);
            }
        }

        public static string GenerateVaccinationMessage(long number)
        {
            string message = "";
            //all my hard coded values for ID numbers
            switch (number)
            {
                case 8106173730380:
                    message = "***********************************************" +
                        "\nVACDINATION INFORMATION" +
                        "\nID: " + number +
                        "\nName: Ricky Tan" +
                        "\nAge: 42" +
                        "\nVaccines Utilised: HepB (Hepatitis B)" +
                        "\n                   Pfizer (COVID-19)";
                    break;
                case 8807016246365:
                    message = "***********************************************************" +
                        "\nVACINATION INFORMATION" +
                        "\nID: " + number +
                        "\nName: James Steven Carter" +
                        "\nAge: 35" +
                        "\nVaccines Utilised: Quadrivalent Influenze Vaccine (Influenza)" +
                        "\n                   Pfizer (COVID-19)";
                    break;
                case 8903083476915:
                    message = "***********************************************" +
                        "\nVACINATION INFORMATION" +
                        "\nID: " + number +
                        "\nName: Yan Naing Lee" +
                        "\nAge: 34" +
                        "\nVaccines Utilised: Vaxchora (Cholera)" +
                        "\n                   BCG (Tuberculosis)";
                    break;
                case 9812047204723:
                    message = "***********************************************" +
                        "\nVACINATION INFORMATION" +
                        "\nID: " + number +
                        "\nName: Isabella Molina" +
                        "\nAge: 25" +
                        "\nVaccines Utilised: Vaxchora (Cholera)" +
                        "\n                   Pfizer (COVID-19)" +
                        "\n                   Chickenpox (Varicella)";
                    break;
                case 6405168740916:
                    message = "***********************************************" +
                        "\nVACINATION INFORMATION" +
                        "\nID: " + number +
                        "\nName: Captain Chin" +
                        "\nAge: 59" +
                        "\nVaccines Utilised: HepB (Hepatitis B)" +
                        "\n                   BCG (Tuberculosis)";
                    break;
                default:
                    message = "Invalid Number, Please try again.";
                    break;
            }
            return message;
        }
    }
}

/*
 Code Attribution :
https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-http-webhook-trigger?tabs=python-v2%2Cin-process%2Cfunctionsv2&pivots=programming-language-csharp from Microsft
https://www.microsoft.com/en-za

https://www.c-sharpcorner.com/article/how-to-create-an-http-trigger-azure-function-app-using-visual-studio-20172/ from MANITEJA VEGI
https://www.c-sharpcorner.com/members/maniteja-vegi

https://azurelessons.com/azure-function-http-trigger/ from Bijay Kumar
https://azurelessons.com/author/fewlines4biju/

https://youtu.be/f70dhIgcBsQ?si=D47js-Hye_LgwzC9 from TechWebDots
https://youtube.com/@TechWebDots?si=gs5jnqoH3GK9cUTo

https://youtu.be/zIfxkub7CLY?si=mNwccXz5QMV3Jbqo from IAMTimCorrey
https://youtube.com/@IAmTimCorey?si=i4SglSht8Nnb1ukt
 */