using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Test
{
    public class BossEnemyShould
    {
        [Fact]
        public void HaveCorrectPower()
        {
            BossEnemy sut = new BossEnemy();
            Assert.Equal(166.67, sut.TotalSpecialAttackPower,2);
        }
    }
}
