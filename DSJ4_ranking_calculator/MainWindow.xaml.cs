using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace DSJ4_ranking_calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    enum Tournament
    {
        Fourhillstournament,
        RawAir,
        Willingen5,
        Planica7
    }

    enum City
    {
        Kulm,
        Bischofshofen,
        Engelberg,
        GaPa,
        Harrachov,
        Klingenthal,
        Kuopio,
        Kuusamo,
        Lahti,
        Lillehammer,
        Oberstdorf,
        ParkCity,
        Planica,
        Sapporo,
        ValDiFiemme,
        Villach,
        Willingen,
        Wisla,
        Zakopane
    }

    public partial class MainWindow : Window
    {
        private List<Jumper> jumpers;
        private List<Country> countries;
        private Statistics statistics;

        public MainWindow()
        {
            InitializeComponent();
            SetElementSize();
            FileChoose();
        }

        public void SetElementSize()
        {
            PathText.Width = SystemParameters.PrimaryScreenWidth - 260;
            Stats.Width = SystemParameters.PrimaryScreenWidth - 200;
            Stats.Height = SystemParameters.PrimaryScreenHeight - 120;
        }

        public void FileChoose()
        {
//            PathText.Text = AppDomain.CurrentDomain.BaseDirectory;
            PathText.Text = "c:\\Users\\kamle\\Documents\\Deluxe Ski Jump 4\\Stats\\";
        }

        private void ChooseDirectory(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            // OK button was pressed.
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                PathText.Text = dialog.SelectedPath;
            }
        }

        private void ShowImage(string imageName)
        {
            var uriSource = new Uri(@imageName, UriKind.Relative);
            Image.Source = new BitmapImage(uriSource);
        }

        private string printJumperWorldCupOnGUI(Jumper jumper, int position)
        {
            return $"{position, 3}. {jumper.Name + " " + jumper.Surname, -40}{jumper.Country, 3}{jumper.WorldCup, 10}\n";
        }

        private string printJumper4HillsOnGUI(Jumper jumper, int position)
        {
            return $"{position,3}. {jumper.Name + " " + jumper.Surname,-40}{jumper.Country,3}{jumper.FourHills,10:0.0}\n";
        }

        private string printJumperRawAirOnGUI(Jumper jumper, int position)
        {
            return $"{position,3}. {jumper.Name + " " + jumper.Surname,-40}{jumper.Country,3}{jumper.RawAir,10:0.0}\n";
        }

        private string printJumperWillingen5OnGUI(Jumper jumper, int position)
        {
            return $"{position,3}. {jumper.Name + " " + jumper.Surname,-40}{jumper.Country,3}{jumper.Willingen5,10:0.0}\n";
        }

        private string printJumperPlanica7OnGUI(Jumper jumper, int position)
        {
            return $"{position,3}. {jumper.Name + " " + jumper.Surname,-40}{jumper.Country,3}{jumper.Planica7,10:0.0}\n";
        }

        private string printJumperFlyingCupOnGUI(Jumper jumper, int position)
        {
            return $"{position,3}. {jumper.Name + " " + jumper.Surname,-40}{jumper.Country,3}{jumper.FlyingCup,10}\n";
        }

        private string printJumperNormalCupOnGUI(Jumper jumper, int position)
        {
            return $"{position,3}. {jumper.Name + " " + jumper.Surname,-40}{jumper.Country,3}{jumper.NormalCup,10}\n";
        }

        private string printTeamOnGUI(Country country, int position)
        {
            return $"{position,3}. {country.CountryName,-30}{country.ShortName,3}{country.Points,10}\n";
        }

        private string printJumperDistanceOnGUI(Jumper jumper, int position)
        {
            return $"{position,3}. {jumper.Name + " " + jumper.Surname,-40}{jumper.Country,3}{jumper.LongestDistance,10:0.0} m\n";
        }

        private void ShowWorldCup()
        {
            ShowImage("world_cup.png");
            Stats.Text = statistics.WorldCup.ToString();
        }

        private void ShowWorldCupHandler(object sender, RoutedEventArgs e)
        {
            ShowWorldCup();
        }

        private void ShowFourHills(object sender, RoutedEventArgs e)
        {
            ShowImage("tcs.png");
            Stats.Text = statistics.FourHillsTournament.ToString();
        }

        private void ShowRawAir(object sender, RoutedEventArgs e)
        {
            ShowImage("raw_air.png");
            Stats.Text = statistics.RawAir.ToString();
        }

        private void ShowW5(object sender, RoutedEventArgs e)
        {
            ShowImage("w5.jpg");
            Stats.Text = statistics.Willingen5.ToString();
        }

        private void ShowP7(object sender, RoutedEventArgs e)
        {
            ShowImage("p7.jpg");
            Stats.Text = statistics.Planica7.ToString();
        }

        private void ShowFlyingCup(object sender, RoutedEventArgs e)
        {
            ShowImage("world_cup.png");
            Stats.Text = statistics.FlyingCup.ToString();
        }

        private void ShowNormalHills(object sender, RoutedEventArgs e)
        {
            ShowImage("world_cup.png");
            Stats.Text = statistics.NormalCup.ToString();
        }

        private void ShowTeamCup(object sender, RoutedEventArgs e)
        {
            ShowImage("world_cup.png");
            Stats.Text = statistics.TeamCup.ToString();
        }

        private void ShowDistances(object sender, RoutedEventArgs e)
        {
            ShowImage("distance.png");
            Stats.Text = statistics.LongestDistance.ToString();

        }

        private void FillStringBuilders()
        {
            List<Jumper> sortedDistances = jumpers.OrderByDescending(x => x.LongestDistance).ToList();
            List<Jumper> sortedNormalCup = jumpers.OrderByDescending(x => x.NormalCup).ToList();
            List<Jumper> sortedFlyingCup = jumpers.OrderByDescending(x => x.FlyingCup).ToList();
            List<Jumper> sortedW5 = jumpers.OrderByDescending(x => x.Willingen5).ToList();
            List<Jumper> sortedP7 = jumpers.OrderByDescending(x => x.Planica7).ToList();
            List<Jumper> sortedRawAir = jumpers.OrderByDescending(x => x.RawAir).ToList();
            List<Jumper> sorted4Hills = jumpers.OrderByDescending(x => x.FourHills).ToList();
            List<Jumper> sortedWorldCup = jumpers.OrderByDescending(x => x.WorldCup).ToList();
            for (int i = 1; i < sortedWorldCup.Count + 1; ++i)
            {
                statistics.WorldCup.Append(printJumperWorldCupOnGUI(sortedWorldCup.ElementAt(i - 1), i));
                statistics.FourHillsTournament.Append(printJumper4HillsOnGUI(sorted4Hills.ElementAt(i - 1), i));
                statistics.RawAir.Append(printJumperRawAirOnGUI(sortedRawAir.ElementAt(i - 1), i));
                statistics.Willingen5.Append(printJumperWillingen5OnGUI(sortedW5.ElementAt(i - 1), i));
                statistics.Planica7.Append(printJumperPlanica7OnGUI(sortedP7.ElementAt(i - 1), i));
                statistics.FlyingCup.Append(printJumperFlyingCupOnGUI(sortedFlyingCup.ElementAt(i - 1), i));
                statistics.NormalCup.Append(printJumperNormalCupOnGUI(sortedNormalCup.ElementAt(i - 1), i));
                statistics.LongestDistance.Append(printJumperDistanceOnGUI(sortedDistances.ElementAt(i - 1), i));
            }
            List<Country> sortedTeamCup = countries.OrderByDescending(x => x.Points).ToList();
            for (int i = 1; i < sortedTeamCup.Count + 1; ++i)
                statistics.TeamCup.Append(printTeamOnGUI(sortedTeamCup.ElementAt(i - 1), i));
        }

        private void GenerateStats(object sender, RoutedEventArgs e)
        {
            statistics = new Statistics();
            ImportJumpers();
            ImportCountries();
            List<String> files = GetFilenames();
            foreach (var file in files)
            {
                ReadFile(file);
            }

            FillStringBuilders();
            EnableButtons();
            ShowWorldCup();
        }

        private void EnableButtons()
        {
            WorldCupButton.IsEnabled = true;
            FourHillsButton.IsEnabled = true;
            RawAirButton.IsEnabled = true;
            RawAirButton.Foreground = Brushes.DarkBlue;
            Willingen5Button.IsEnabled = true;
            Planica7Button.IsEnabled = true;
            FlyingCupButton.IsEnabled = true;
            NormalCupButton.IsEnabled = true;
            TeamCupButton.IsEnabled = true;
            LongestDistanceButton.IsEnabled = true;
        }

        private void PrintList()
        {
            StringBuilder s = new StringBuilder();
            foreach (var item in jumpers)
            {
                s.Append(item.ToString());
                s.Append("\n");
            }

            Stats.Text = s.ToString();
        }

        private void ImportJumpers()
        {
            jumpers = new List<Jumper>();
            string[] lines = System.IO.File.ReadAllLines(PathText.Text + "\\jumpers.txt");
            foreach (string line in lines)
            {
                string[] data = System.Text.RegularExpressions.Regex.Split(line, @"\s{1,}");
                Jumper jumper = new Jumper(data[0], data[1], data[2]);

                jumpers.Add(jumper);
            }
        }

        private void ImportCountries()
        {
            countries = new List<Country>();
            string[] lines = System.IO.File.ReadAllLines(PathText.Text + "\\countries.txt");
            foreach (string line in lines)
            {
                string[] data = System.Text.RegularExpressions.Regex.Split(line, @"\s{1,}");
                Country country = new Country(data[0], data[1]);

                countries.Add(country);
            }
        }

        private List<string> GetFilenames()
        {
            List<string> result = new List<string>(); 
            DirectoryInfo dinfo = new DirectoryInfo(PathText.Text);
            FileInfo[] Files = dinfo.GetFiles("*.txt");
            foreach (FileInfo file in Files)
            {
                if(file.Name.Split(' ')[0].Equals("Puchar"))
                    result.Add(file.Name);
            }

            return result;
        }

        private Hill IdentifyHill(string filename)
        {
            string[] splited = filename.Split(' ');
            int HS = Convert.ToInt32(splited[splited.Length - 3].Substring(2));
            string name;
            if (splited.Length == 7)
                name = splited[splited.Length - 4];
            else if (splited.Length == 8)
                name = splited[splited.Length - 5] + splited[splited.Length - 4];
            else
                name = splited[splited.Length - 6] + splited[splited.Length - 5] + splited[splited.Length - 4];
            return new Hill(name, HS);
        }

        private bool FilterQualification(Hill hill)
        {
            return hill.Name == City.Kuopio ||
                   hill.Name == City.Lahti ||
                   hill.Name == City.Lillehammer ||
                   hill.Name == City.Willingen ||
                   hill.Name == City.Planica;
        }

        private bool FilterTeamToInvidual(Hill hill)
        {
            return hill.Name == City.Willingen ||
                   hill.Name == City.Planica ||
                   hill.Name == City.Lillehammer;
        }

        private void ReadFile(string filename)
        {
            StreamReader reader = new StreamReader(PathText.Text + "\\" + filename);
            string[] words = System.Text.RegularExpressions.Regex.Split(reader.ReadToEnd(), @"\s{1,}");
            int index = 0;

            if (filename.Contains("Klasyfikacja"))
            {
                if(filename.Contains("Świata"))
                    CalculateCountriesFromIndividual(words);
                else
                    CalculateCountriesFromTeam(words);
                return;
            }

            Hill hill = IdentifyHill(filename);


            if (filename.Contains("kwalifikacji") && FilterQualification(hill))
                CalculateQuali(words, hill);
            else if(filename.Contains("kwalifikacji"))
                CalculateQualiDistances(words, hill);
            else if (filename.Contains("Drużynowy") && FilterTeamToInvidual(hill))
                CalculateTeamToInvidual(words, hill);
            else if (filename.Contains("Drużynowy"))
                CalculateTeamToInvidualDistances(words, hill);
            else
            {
                AddDistances(words);
                
                if (hill.HS < 120)
                    AddNormalOrFlyingCupPoints(words, false);
                else if (hill.HS > 180)
                    AddNormalOrFlyingCupPoints(words, true);

                if (hill.Name == City.Oberstdorf || hill.Name == City.GaPa ||
                    hill.Name == City.Villach || (hill.Name == City.Bischofshofen && hill.HS == 140))
                    AddTournamentPoints(words, Tournament.Fourhillstournament);
                else if(hill.Name == City.Kuopio || hill.Name == City.Lahti ||
                        hill.Name == City.Lillehammer)
                    AddTournamentPoints(words, Tournament.RawAir);
                else if (hill.Name == City.Willingen)
                    AddTournamentPoints(words, Tournament.Willingen5);
                else if(hill.Name == City.Planica)
                    AddTournamentPoints(words, Tournament.Planica7);
            }
        }

        private void AddNormalOrFlyingCupPoints(string[] words, bool flying)
        {
            bool exequo = false;

            int index = 0, position = 0, exCounter = 0;
            while (!words[index].Equals("1."))
                ++index;
            while (index < words.Length)
            {
                if (!exequo)
                {
                    ++index;
                    position += 1 + exCounter;
                    exCounter = 0;
                }

                if (exequo) ++exCounter;

                if (position > 30) break;
                ++index;
                if (index >= words.Length) break;
                string name = words[index];
                string surname = words[index + 1];
                index += 8;
                
                Jumper jumper = jumpers.Find(x => x.Name.Equals(name) && x.Surname.Equals(surname));
                if(flying)
                    jumper.FlyingCup += GetPointsFromPosition(position);
                else
                    jumper.NormalCup += GetPointsFromPosition(position);

                exequo = !words[index].EndsWith(".");
            }
        }
        
        private void CalculateCountriesFromIndividual(string[] words)
        {
            int index = 0;
            while (!words[index].Equals("1.")) ++index;

            string countryName, jumperName, jumperSurname;
            int points;
            bool exequo = false;
            PrintList();
            while (index < words.Length)
            {
                if (!exequo) index += 3;
                else index += 2;
                if (index >= words.Length) break;

                jumperName = words[index - 2];
                jumperSurname = words[index - 1];
                countryName = words[index];
                index += 4;
                points = Convert.ToInt32(words[index]);
                Country country = countries.Find(x => x.ShortName.Equals(countryName));
                country.Points += points;
                Jumper jumper = jumpers.Find(x => x.Name.Equals(jumperName) && x.Surname.Equals(jumperSurname));
                jumper.WorldCup = points;

                ++index;
                if (index >= words.Length) break;
                if (words[index].EndsWith(".")) exequo = false;
                else exequo = true;

            }
        }

        private void CalculateCountriesFromTeam(string[] words)
        {
            int index = 0;
            while (!words[index].Equals("1.")) ++index;

            string countryName;
            int points;
            bool exequo = false;
            PrintList();
            while (index < words.Length)
            {
                if (!exequo) index += 2;
                else ++index;
                if (index >= words.Length) break;

                countryName = words[index];
                index += 4;
                points = Convert.ToInt32(words[index]);
                Country country = countries.Find(x => x.ShortName.Equals(countryName));
                country.Points += points;

                ++index;
                if (index >= words.Length) break;
                if (words[index].EndsWith(".")) exequo = false;
                else exequo = true;
            }
        }

        private void CalculateQuali(string[] words, Hill hill)
        {
            bool exequo = false, w5 = false, p7 = false;
            if (hill.Name == City.Willingen)
                w5 = true;
            else if (hill.Name == City.Planica)
                p7 = true;

            int index = 0;
            while (!words[index].Equals("1."))
                ++index;
            while (index < words.Length)
            {
                if (!exequo) ++index;
                ++index;
                if (index >= words.Length) break;
                string name = words[index];
                string surname = words[index + 1];
                index += 5;
                double distance = double.Parse(words[index-2], System.Globalization.CultureInfo.InvariantCulture);
                double points = double.Parse(words[index], System.Globalization.CultureInfo.InvariantCulture);

                Jumper jumper = jumpers.Find(x => x.Name.Equals(name) && x.Surname.Equals(surname));
                jumper.LongestDistance += distance;
                if (w5) jumper.Willingen5 += points;
                else if (p7) jumper.Planica7 += points;
                else jumper.RawAir += points;

                if (words[index + 1].StartsWith("q") || words[index + 1].StartsWith("Q")) index += 2;
                else ++index;

                exequo = !words[index].EndsWith(".");
            }
        }

        private void CalculateQualiDistances(string[] words, Hill hill)
        {
            bool exequo = false;
            int index = 0;
            while (!words[index].Equals("1."))
                ++index;
            while (index < words.Length)
            {
                if (!exequo) ++index;
                ++index;
                if (index >= words.Length) break;
                string name = words[index];
                string surname = words[index + 1];
                index += 5;
                double distance = double.Parse(words[index - 2], System.Globalization.CultureInfo.InvariantCulture);
                
                Jumper jumper = jumpers.Find(x => x.Name.Equals(name) && x.Surname.Equals(surname));
                jumper.LongestDistance += distance;
                
                if (words[index + 1].StartsWith("q") || words[index + 1].StartsWith("Q")) index += 2;
                else ++index;

                exequo = !words[index].EndsWith(".");
            }
        }

        private void CalculateTeamToInvidual(string[] words, Hill hill)
        {
            bool exequo = false, w5 = false, p7 = false;
            if (hill.Name == City.Willingen)
                w5 = true;
            else if (hill.Name == City.Planica)
                p7 = true;

            int index = 0;
            while (!words[index].Equals("1."))
                ++index;
            while (index < words.Length)
            {
                if (!exequo) index += 6;
                else index += 5;
                if (index >= words.Length) break;
                bool quali = true, flag = false;
                for (int jumperCounter = 0; jumperCounter < 4; ++jumperCounter)
                {
                    string name = words[index];
                    string surname = words[index + 1];
                    if (quali) index += 6;
                    else index += 4;
                    if (words[index].Contains("-") && !flag)
                    {
                        quali = false;
                        flag = true;
                        index -= 2;
                    }

                    double distance = .0;
                    if (quali)
                        distance += double.Parse(words[index - 4], System.Globalization.CultureInfo.InvariantCulture);

                    distance += double.Parse(words[index - 2], System.Globalization.CultureInfo.InvariantCulture);

                    double points = double.Parse(words[index], System.Globalization.CultureInfo.InvariantCulture);
                    Jumper jumper = jumpers.Find(x => x.Name.Equals(name) && x.Surname.Equals(surname));
                    jumper.LongestDistance += distance;
                    if (w5) jumper.Willingen5 += points;
                    else if (p7) jumper.Planica7 += points;
                    else jumper.RawAir += points;
                    index += 3;
                }
                if (index >= words.Length) break;
                exequo = !words[index].EndsWith(".");
            }
        }

        private void CalculateTeamToInvidualDistances(string[] words, Hill hill)
        {
            bool exequo = false;

            int index = 0;
            while (!words[index].Equals("1."))
                ++index;
            while (index < words.Length)
            {
                if (!exequo) index += 6;
                else index += 5;
                if (index >= words.Length) break;
                bool quali = true, flag = false;
                for (int jumperCounter = 0; jumperCounter < 4; ++jumperCounter)
                {
                    string name = words[index];
                    string surname = words[index + 1];
                    if (quali) index += 6;
                    else index += 4;
                    if (words[index].Contains("-") && !flag)
                    {
                        quali = false;
                        flag = true;
                        index -= 2;
                    }

                    double distance = .0;
                    if (quali)
                        distance += double.Parse(words[index - 4], System.Globalization.CultureInfo.InvariantCulture);

                    distance += double.Parse(words[index - 2], System.Globalization.CultureInfo.InvariantCulture);

                    Jumper jumper = jumpers.Find(x => x.Name.Equals(name) && x.Surname.Equals(surname));
                    jumper.LongestDistance += distance;
                    index += 3;
                }

                --index;
                if (index >= words.Length) break;
                string kupa = words[index];
                Console.WriteLine(kupa);
                exequo = !words[index].EndsWith(".");
            }
        }

        private void AddTournamentPoints(string[] words, Tournament tournament)
        {
            bool exequo = false, quali = true, flag = false;

            int index = 0;
            while (!words[index].Equals("1."))
                ++index;
            while (index < words.Length)
            {
                if (!exequo) ++index;

                ++index;
                if (index >= words.Length) break;
                string name = words[index];
                string surname = words[index + 1];
                if (quali) index += 7;
                else index += 5;
                if (!words[index].Contains(".") && !flag)
                {
                    quali = false;
                    flag = true;
                    index -= 2;
                }

                double points = double.Parse(words[index], System.Globalization.CultureInfo.InvariantCulture);

                Jumper jumper = jumpers.Find(x => x.Name.Equals(name) && x.Surname.Equals(surname));
                if(tournament == Tournament.Fourhillstournament)
                    jumper.FourHills += points;
                else if (tournament == Tournament.RawAir)
                    jumper.RawAir += points;
                else if (tournament == Tournament.Willingen5)
                    jumper.Willingen5 += points;
                else if (tournament == Tournament.Planica7)
                    jumper.Planica7 += points;

                ++index;
                exequo = !words[index].EndsWith(".");
            }
        }

        private void AddDistances(string[] words)
        {
            bool exequo = false, quali = true, flag = false;

            int index = 0;
            while (!words[index].Equals("1."))
                ++index;
            while (index < words.Length)
            {
                if (!exequo) ++index;

                ++index;
                if (index >= words.Length) break;
                string name = words[index];
                string surname = words[index + 1];
                if (quali) index += 7;
                else index += 5;
                if (!words[index].Contains(".") && !flag)
                {
                    quali = false;
                    flag = true;
                    index -= 2;
                }

                double distance = .0;
                if(quali)
                    distance += double.Parse(words[index - 4], System.Globalization.CultureInfo.InvariantCulture);

                distance += double.Parse(words[index - 2], System.Globalization.CultureInfo.InvariantCulture);

                Jumper jumper = jumpers.Find(x => x.Name.Equals(name) && x.Surname.Equals(surname));
                jumper.LongestDistance += distance;

                ++index;
                exequo = !words[index].EndsWith(".");
            }
        }


        public int GetPointsFromPosition(int position)
        {
            switch (position)
            {
                case 1: return 100;
                case 2: return 80;
                case 3: return 60;
                case 4: return 50;
                case 5: return 45;
                case 6: return 40;
                case 7: return 36;
                case 8: return 32;
                case 9: return 29;
                case 10: return 26;
                case 11: return 24;
                case 12: return 22;
                case 13: return 20;
                case 14: return 18;
                case 15: return 16;
                case 16: return 15;
                case 17: return 14;
                case 18: return 13;
                case 19: return 12;
                case 20: return 11;
                case 21: return 10;
                case 22: return 9;
                case 23: return 8;
                case 24: return 7;
                case 25: return 6;
                case 26: return 5;
                case 27: return 4;
                case 28: return 3;
                case 29: return 2;
                case 30: return 1;

                default: return 0;
            }
        }
    }

}
