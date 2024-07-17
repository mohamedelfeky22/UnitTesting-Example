namespace GameEngine.Test
{
    public class PlayerCharacterShould
    {
        //Test boolean Values 
        [Fact]
        public void beInExperiencedWhenNew()
        {
            //Arrange 
            PlayerCharacter sut = new PlayerCharacter();

            //Act 

            //Assert
            Assert.True(sut.IsNoob);
        }


        //Test string  Values 
        [Fact]
        public void CalculateFullName()
        {
            //Arrange
            PlayerCharacter playerCharacter = new PlayerCharacter();
            //Act
            playerCharacter.FirstName = "MO";
            playerCharacter.LastName = "Feky";
            //Assert
            Assert.Equal(playerCharacter.FullName, "MO Feky");
        }
        [Fact]

        public void HaveFullNamestartsWithFirstName()
        {
            //Arrange
            PlayerCharacter playerCharacter = new PlayerCharacter();
            //Act
            playerCharacter.FirstName = "MO";
            playerCharacter.LastName = "Feky";
            //Assert
            Assert.StartsWith("MO", playerCharacter.FullName);
        }

        [Fact]

        public void HaveFullNameendsWithlastName()
        {
            //Arrange
            PlayerCharacter playerCharacter = new PlayerCharacter();
            //Act
            playerCharacter.FirstName = "MO";
            playerCharacter.LastName = "Feky";
            //Assert
            Assert.EndsWith("Feky", playerCharacter.FullName);
        }
        [Fact]
        public void CalculateFullName_ignoreCaseSenstivity()
        {
            //Arrange
            PlayerCharacter playerCharacter = new PlayerCharacter();
            //Act
            playerCharacter.FirstName = "MO";
            playerCharacter.LastName = "FEKY";
            //Assert
            Assert.Equal(playerCharacter.FullName, "MO Feky", ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_ContainSubString()
        {
            //Arrange
            PlayerCharacter playerCharacter = new PlayerCharacter();
            //Act
            playerCharacter.FirstName = "MO";
            playerCharacter.LastName = "FEKY";
            //Assert
            Assert.Contains("O F", playerCharacter.FullName);
        }

        [Fact]
        public void CalculateFullName_WithTitleCase() //match REGEX
        {
            //Arrange
            PlayerCharacter playerCharacter = new PlayerCharacter();
            //Act
            playerCharacter.FirstName = "Mo";
            playerCharacter.LastName = "Feky";
            //
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", playerCharacter.FullName);
        }

        //Test Numeric Values 

        [Fact]
        public void startwithDeafultValues()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);
        }


        [Fact]
        public void increaseHealthAfterSleep()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            //Act
            sut.Sleep();
            //Assert
            // Assert.True(sut.Health>=101 && sut.Health<=200);
            Assert.InRange(sut.Health, 101, 200);
        }

        [Fact]

        public void NotHaveNickNameByDeafult()
        {
            PlayerCharacter sut = new PlayerCharacter();
            Assert.Null(sut.Nickname);
        }

        //Test collection Values

        [Fact]
        public void HaveALogBow()
        {
            PlayerCharacter sut = new PlayerCharacter();
            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void NotHaveAstaffOfWonder()
        {
            PlayerCharacter sut = new PlayerCharacter();
            Assert.DoesNotContain("AstaffOfWonder", sut.Weapons);
        }


        [Fact]
        public void HaveAtListKindOfSword() //have at least a  value
        {
            PlayerCharacter sut = new PlayerCharacter();
            Assert.Contains(sut.Weapons,w=>w.Contains("Sword"));
        }


        [Fact]
        public void HaveAllExpectedWapons() //have at least a  value
        {
            PlayerCharacter sut = new PlayerCharacter();
            var expectedWapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };

            Assert.Equal(sut.Weapons,expectedWapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons() //loop on all values
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.All(sut.Weapons,w=>Assert.False(string.IsNullOrWhiteSpace(w)));  
        }



        [Fact]
        public void TakeZeroDamage()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.TakeDamage(0);
            Assert.Equal(100, sut.Health);
        }
        [Fact]
        public void TakeSmallDamage() 
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.TakeDamage(1);
            Assert.Equal(99, sut.Health);
        }

        [Fact]
        public void TakemediumDamage() 
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.TakeDamage(50);
            Assert.Equal(50, sut.Health);
        }


        [Fact]
        public void HaveMinimum1Health() 
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.TakeDamage(101);
            Assert.Equal(1, sut.Health);
        }

        //Data driven tests
        [Theory]
        [InlineData(0,100)]
        [InlineData(1, 99)]
        [InlineData(50, 50)]
        [InlineData(101, 1)]
        public void TakeDamageInlineData(int damage,int expectedHealth)
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }


          [Theory]
          [MemberData(nameof(InternalHealthTestData.Testdata), MemberType = typeof(InternalHealthTestData))]
      //  [MemberData("Testdata",MemberType=typeof(HealthTestData))]
        public void TakeDamageMemberData(int damage, int expectedHealth)
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }


        [Theory]
        [MemberData(nameof(ExternalHealthTestData.Testdata), MemberType = typeof(ExternalHealthTestData))]
        public void TakeDamageExternalSourcesCV(int damage, int expectedHealth)
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }

        [Theory]
        [HealthTestData]
        public void TakeDamageCustomDataAttributes(int damage, int expectedHealth)
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }


    }

}