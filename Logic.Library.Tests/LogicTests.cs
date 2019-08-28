using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

/* Author Ilgiz.
 * Tests for this app. I used NUnit v3.12 and TestAdapter v3.15.
 * For demonstration I created one test.
 */

namespace Logic.Library.Tests
{
    [TestFixture]
    public class LogicTests
    {
        [Test]
        public void DeckHasCards()
        {
            Deck deck = new Deck(52);
            string firstcard = deck.ShowCards().ToString();
            Assert.IsNotEmpty(firstcard);
        }
    }
}
