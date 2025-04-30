using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using UI.DTOs;
using Newtonsoft.Json.Linq;



namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public async void CreateGame(object sender, EventArgs e)
        {
            // Request készítés
            string url = "https://localhost:7201/create_game";
            GameCreateRequest request = new GameCreateRequest();
            request.userId = 0;
            request.difficulty = 10;

            // Regisztráció kérelem elküldése
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            var handler = new HttpClientHandler { AllowAutoRedirect = true };


            Game activeGame = new Game();

            using (HttpClient client = new HttpClient(handler))
            {
                client.Timeout = TimeSpan.FromMinutes(2);
                HttpContent jsonStringHttp = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var requestHttp = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = jsonStringHttp
                };

                HttpResponseMessage responseHttp = await client.SendAsync(requestHttp, HttpCompletionOption.ResponseContentRead);
                string responseString = responseHttp.Content.ReadAsStringAsync().Result;
                JObject responseJson = JObject.Parse(responseString);

                if (responseHttp.StatusCode == HttpStatusCode.OK)
                {
                    MessageBox.Show($"Game \"{responseJson["id"]}\" created", "Successful registration", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    activeGame.Id = (int)responseJson["id"];
                    activeGame.BallSpeedLeft = (int)responseJson["ballSpeedLeft"];
                    activeGame.BallSpeedTop = (int)responseJson["ballSpeedTop"];
                    activeGame.BallPositionLeft = (int)responseJson["ballPositionLeft"];
                    activeGame.BallPositionTop = (int)responseJson["ballPositionTop"];
                    activeGame.BatPositionLeft = (int)responseJson["batPositionLeft"];
                    activeGame.IsFinished = (bool)responseJson["isFinished"];
                    activeGame.UserId = (int)responseJson["userId"];
                    activeGame.ScoreId = (int)responseJson["scoreId"];
                }
                else
                {
                    string responseCode = (string)responseJson["status"];
                    string responseMessage = (string)responseJson["message"];
                    string errorMessage = $"Error code: {responseCode}\n{responseMessage}";
                    MessageBox.Show(errorMessage, "Registration failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            GameWindow gamewindow = new GameWindow(activeGame);
            gamewindow.Show();
        }
    }
}
