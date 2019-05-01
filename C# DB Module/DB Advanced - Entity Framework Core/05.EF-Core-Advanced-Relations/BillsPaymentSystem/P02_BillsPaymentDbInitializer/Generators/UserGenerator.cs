namespace P02_BillsPaymentDbInitializer.Generators
{
    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;
    using System;
    using System.Text;

    public class UserGenerator
    {
        private static Random rnd = new Random();

        internal static void InitialUserSeed(BillsPaymentSystemContext db)
        {
            for (int i = 0; i < names.Length; i++)
            {
                var currentUser = new User()
                {
                    FirstName = names[i].Split(' ')[0],
                    LastName = names[i].Split(' ')[1],
                    Email = $"{names[i].Split(' ')[0]}.{names[i].Split(' ')[1]}@{domains[rnd.Next(0, domains.Length)]}",
                    Password = GenerateRandomPassword()
                };

                db.Users.Add(currentUser);
                db.SaveChanges();
            }
        }

        private static string GenerateRandomPassword()
        {
            var symbols = "QWERTYUIOPLKJHGFDSAZXCVBNMqwertyuioplkjhgfdsazxcvbnm1234567890".ToCharArray();

            var password = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                password.Append(symbols[rnd.Next(0, symbols.Length)]);
            }

            return password.ToString();
        }

        private static string[] domains =
        {
            "abv.bg",
            "mail.bg",
            "gmail.com",
            "softuni.bg"
        };

        private static string[] names =
        {
            "Guy Gilbert", "Kevin Brown", "Roberto Tamburello", "Rob Walters", "Thierry D'Hers", "David Bradley", "JoLynn Dobney", "Ruth Ellerbrock", "Gail Erickson", "Barry Johnson", "Jossef Goldberg", "Terri Duffy", "Sidney Higa", "Taylor Maxwell", "Jeffrey Ford", "Jo Brown", "Doris Hartwig", "John Campbell", "Diane Glimp", "Steven Selikoff", "Peter Krebs", "Stuart Munson", "Greg Alderson", "David Johnson", "Zheng Mu", "Ivo Salmre", "Paul Komosinski", "Ashvini Sharma", "Kendall Keil", "Paula Barreto de Mattos", "Alejandro McGuel", "Garrett Young", "Jian Shuo Wang", "Susan Eaton", "Vamsi Kuppa", "Alice Ciccu", "Simon Rapier", "Jinghao Liu", "Michael Hines", "Yvonne McKay", "Peng Wu", "Jean Trenary", "Russell Hunter", "A. Scott Wright", "Fred Northup", "Sariya Harnpadoungsataya", "Willis Johnson", "Jun Cao", "Christian Kleinerman", "Susan Metters", "Reuben D'sa", "Kirk Koenigsbauer", "David Ortiz", "Tengiz Kharatishvili", "Hanying Feng", "Kevin Liu", "Annik Stahl", "Suroor Fatima", "Deborah Poe", "Jim Scardelis", "Carole Poland", "George Li", "Gary Yukish", "Cristian Petculescu", "Raymond Sam", "Janaina Bueno", "Bob Hohman", "Shammi Mohamed", "Linda Moschell", "Mindy Martin", "Wendy Kahn", "Kim Ralls",
            "Sandra Reategui Alayo", "Kok-Ho Loh", "Douglas Hite", "James Kramer", "Sean Alexander", "Nitin Mirchandani", "Diane Margheim",
            "Rebecca Laszlo", "Rajesh Patel", "Vidur Luthra", "John Evans", "Nancy Anderson", "Pilar Ackerman", "David Yalovsky", "David Hamilton",
            "Laura Steele", "Margie Shoop", "Zainal Arifin", "Lorraine Nay", "Fadi Fakhouri", "Ryan Cornelsen", "Candy Spoon", "Nuan Yu",
            "William Vong", "Bjorn Rettig", "Scott Gode", "Michael Rothkugel", "Lane Sacksteder", "Pete Male", "Dan Bacon", "David Barber",
            "Lolan Song", "Paula Nartker", "Mary Gibson", "Mindaugas Krapauskas", "Eric Gubbels", "Ken Sanchez", "Jason Watters", "Mark Harrington",
            "Janeth Esteves", "Marc Ingle", "Gigi Matthew", "Paul Singh", "Frank Lee", "Francois Ajenstat", "Diane Tibbott", "Jill Williams",
            "Angela Barbariol", "Matthias Berndt", "Bryan Baker", "Jeff Hay", "Eugene Zabokritski", "Barbara Decker", "Chris Preston", "Sean Chai",
            "Dan Wilson", "Mark McArthur", "Bryan Walton", "Houman Pournasseh", "Sairaj Uddin", "Michiko Osada", "Benjamin Martin", "Cynthia Randall",
            "Kathie Flood", "Britta Simon", "Brian Lloyd", "David Liu", "Laura Norman", "Michael Patten", "Andy Ruth", "Yuhong Li",
            "Robert Rounthwaite", "Andreas Berglund", "Reed Koch", "Linda Randall", "James Hamilton", "Ramesh Meyyappan", "Stephanie Conroy",
            "Samantha Smith", "Tawana Nusbaum", "Denise Smith", "Hao Chen", "Alex Nayberg", "Eugene Kogan", "Brandon Heidepriem", "Dylan Miller",
            "Shane Kim", "John Chen", "Karen Berge", "Jose Lugo", "Mandar Samant", "Mikael Sandberg", "Sameer Tejani", "Dragan Tomic",
            "Carol Philips", "Rob Caron", "Don Hall", "Alan Brewer", "David Lawrence", "Baris Cetinok", "Michael Ray", "Steve Masters",
            "Suchitra Mohan", "Karen Berg", "Terrence Earls", "Barbara Moreland", "Chad Niswonger", "Rostislav Shabalin", "Belinda Newman",
            "Katie McAskill-White", "Russell King", "Jack Richins", "Andrew Hill", "Nicole Holliday", "Frank Miller", "Peter Connelly",
            "Anibal Sousa", "Ken Myer", "Grant Culbertson", "Michael Entin", "Lionel Penuchot", "Thomas Michaels", "Jimmy Bischoff",
            "Michael Vanderhyde", "Lori Kane", "Arvind Rao", "Stefen Hesse", "Hazem Abolrous", "Janet Sheperdigian", "Elizabeth Keyser",
            "Terry Eminhizer", "John Frum", "Merav Netz", "Brian LaMee", "Kitti Lertpiriyasuwat", "Jay Adams", "Jan Miksovsky", "Brenda Diaz",
            "Andrew Cencini", "Chris Norred", "Chris Okelberry", "Shelley Dyck", "Gabe Mares", "Mike Seamans", "Michael Raheem", "Gary Altman",
            "Charles Fitzgerald", "Ebru Ersan", "Sylvester Valdez", "Brian Goldstein", "Linda Meisner", "Betsy Stadick", "Magnus Hedlund",
            "Karan Khanna", "Mary Baker", "Kevin Homer", "Mihail Frintu", "Bonnie Kearney", "Fukiko Ogisu", "Hung-Fu Ting", "Gordon Hee",
            "Kimberly Zimmerman", "Kim Abercrombie", "Sandeep Kaliyath", "Prasanna Samarawickrama", "Frank Pellow", "Min Su", "Eric Brown",
            "Eric Kurjan", "Pat Coleman", "Maciej Dusza", "Erin Hagens", "Patrick Wedge", "Frank Martinez", "Ed Dudenhoefer", "Christopher Hill",
            "Patrick Cook", "Krishna Sunkammurali", "Lori Penor", "Danielle Tiedt", "Sootha Charncherngkha", "Michael Zwilling", "Randy Reeves",
            "John Kane", "Jack Creasey", "Olinda Turner", "Stuart Macrae", "Jo Berry", "Ben Miller", "Tom Vande Velde", "Ovidiu Cracium",
            "Annette Hill", "Janice Galvin", "Reinout Hillmann", "Michael Sullivan", "Stephen Jiang", "Wanida Benshoof", "Sharon Salavaria",
            "John Wood", "Mary Dempsey", "Brian Welcker", "Sheela Word", "Michael Blythe", "Linda Mitchell", "Jillian Carson", "Garrett Vargas",
            "Tsvi Reiter", "Pamela Ansman-Wolfe", "Shu Ito", "Jose Saraiva", "David Campbell", "Amy Alberts", "Jae Pak", "Ranjit Varkey Chudukatil",
            "Tete Mensa-Annan", "Syed Abbas", "Rachel Valdez", "Lynn Tsoflias", "Svetlin Nakov", "Martin Kulov", "George Denchev"
        };
    }
}
