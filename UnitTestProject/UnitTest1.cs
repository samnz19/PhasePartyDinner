using System;
using NUnit.Framework;
using ScrapperLibrary;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            //arange

           // Scrapper scrapper = new Scrapper();

            string Actual = "<div id='entree'><div class='menulist'><p>Curry Puffs <br /><em>$6.00</em></p>" +
                            "<a href='images/Curry-Puff500.jpg' rel='prettyPhoto[Entree]' title='Curry Puffs $6.00'><img src='images/Curry-Puff100.jpg' width='100' height='73' alt='currypuff' /></a></div>" +

                            "<div class='menulist'><p>Prawn Spring Roll <br /><em>$6.50</em></p><a href='images/Springs-Rolls500.jpg' rel='prettyPhoto[Entree]' title='Prawn Spring Roll $6.50'><img src='images/Springs-Rolls100.jpg' width='100' height='64' alt='springroll' /></a>" +
                            "</div><div class='menulist'><p>Roti w/ Satay Sauce <br /><em>$5.00</em></p><a href='images/Roti-w-Satay-500.jpg' rel='prettyPhoto[Entree]' title='Roti w/ Satay Sauce $5.00'><img src='images/Roti-w-Satay-100.jpg' width='100' height='67' alt='roti' /></a></div>" +

                            "<div class='menulist'><p>Garlic Roti <br/>w/ Satay Sauce <br /><em>$6.00</em></p><a href='images/Roti-w-Satay-500.jpg' rel='prettyPhoto[Entree]' title='Roti w/ Satay Sauce $5.00'><img src='images/Roti-w-Satay-100.jpg' width='100' height='67' alt='roti' /></a></div>" +

                            "<div class='menulist'><p>Stuffed Mushrooms <br /><em>$6.50</em></p><a href='images/Stuffed-Mushroom500.jpg' rel='prettyPhoto[Entree]' title='Stuffed Mushrooms $6.50'><img src='images/Stuffed-Mushroom100.jpg' width='100' height='66' alt='mushrooms' /></a></div><div class='menulist'><p>Vegetables Spring Roll <br /><em>$6.00</em></p>" +
                            "<a href='images/Springs-Rolls500.jpg' rel='prettyPhoto[Entree]' title='Vegetrable Spring Roll $6.00'><img src='images/Springs-Rolls100.jpg' width='100' height='64' alt='springroll' /></a></div></div>";
            //act
           // scrapper.FromXml<Scrapper>(Actual);

            Assert.AreEqual(1,1);





            //assert
        }
    }
}
