using UnityEngine;

public class EnemyField : MonoBehaviour {

    public GameObject Enemy;

    private void HowManyEnemies(int kupa) {//int how_many_x, float remainder_x, int how_many_y, float remainder_y) {
        //float remainder_x = field_width % enemy_width;
    }
    //def how_many_enemies(self):
    //    remainder_x = self.field_width % self.enemy_width
    //    remainder_y = self.field_height % self.enemy_height
    //    how_many_x = int ((self.field_width - remainder_x) / (self.enemy_width))
    //    how_many_y = int ((self.field_height - remainder_y) / (self.enemy_height))
    //
    //    if how_many_x % 2 == 0:
    //        how_many_x /= 2
    //        remainder_x += self.enemy_width
    //    else:
    //        how_many_x = ceil(how_many_x / 2)
    //    if how_many_y % 2 == 0:
    //        how_many_y /= 2
    //        remainder_y += self.enemy_height
    //    else:
    //        how_many_y = ceil(how_many_y / 2)
    //
    //    return how_many_x, remainder_x, how_many_y, remainder_y
    //
    //def fill_with_enemies(self, enemies) :
    //    how_many_x, remainder_x, how_many_y, remainder_y = self.how_many_enemies()
    //    self.offset_x = remainder_x/2
    //    self.offset_y = remainder_y / 2
    //    field_offset_y = self.start_y + self.offset_y
    //    for _ in range(int(how_many_y)):
    //        field_offset_x = self.start_x + self.offset_x
    //        for _ in range(int(how_many_x)) :
    //            enemies.append(enemy_ship.EnemyShip(field_offset_x, field_offset_y, self.enemy_width, self.model))
    //            field_offset_x += 2*self.enemy_width
    //        field_offset_y += 2*self.enemy_height
    //    return enemies

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
