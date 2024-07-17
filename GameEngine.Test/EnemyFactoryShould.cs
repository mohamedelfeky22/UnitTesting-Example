using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Test
{
    public class EnemyFactoryShould
    {
        [Fact]
        public void CreateNormalEnemyByDefault()
        {
           EnemyFactory sut = new EnemyFactory();
           Enemy enemy=sut.Create("Monster");
           Assert.IsType<NormalEnemy>(enemy);
        }
        [Fact]
        public void NotCreatebossEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Monster");
            Assert.IsNotType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Monster King", true);
            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_ValidateFileName()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Monster King", true);
            Assert.Equal("Monster King",enemy.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableType()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Monster King", true);
          //  Assert.IsType<Enemy>(enemy);     //type is boss enemy
            Assert.IsAssignableFrom<Enemy>(enemy);  //it will take into account any inhertence
        }

        [Fact]
        public void Createseprateinstances()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        public void NotAllowNullNames()
        {
            EnemyFactory sut = new EnemyFactory();
            //First Approach
            //Assert.Throws<ArgumentNullException>(() => sut.Create(null));
            //Second Approach
            Action action = () => { sut.Create(null); };    
            Assert.Throws<ArgumentNullException>(action);

            //Third Approch ,you specify the Params
            Assert.Throws<ArgumentNullException>("name",() => sut.Create(null));
        }

        [Fact]
        public void OnlyAllowKingorQueenBossEnemies()
        {
            EnemyFactory sut = new EnemyFactory();
            Assert.Throws<EnemyCreationException>(() => sut.Create("Test",true));
        }




    }
}
