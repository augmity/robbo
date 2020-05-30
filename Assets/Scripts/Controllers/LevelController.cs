using UnityEngine;
using Robbo.Models;
using System.Collections.Generic;
using System.Linq;

namespace Robbo.Controllers {

    [System.Serializable]
    public class LevelElement
    {
        public string name;
        public GameObject prefab;
    }

    public class LevelController : MonoBehaviour
    {

        public Sprite[] Sprites;
        public GameObject GenericItem;

        private BoardItem[,] board;

        public void initLevel(Level level) {
            ClearBoard();

            board = new BoardItem[level.board.Length, 16];


            for (int row = 0; row < level.board.Length; row++)
            {
                for (int col = 0; col < 16; col++)
                {
                    var character = level.board[row][col];
                    var prefabName = CharToPrefabName(character);
                    
                    if (prefabName != null)
                    {
                        var prefab = Instantiate(GenericItem, new Vector3(col, -1 * row, 0), Quaternion.identity);

                        var sprite = Sprites.First(x => x.name == prefabName);
                        prefab.GetComponent<SpriteRenderer>().sprite = sprite;

                        board[row, col] = new BoardItem(prefab);
                    }
                }
            }
        }

        private void ClearBoard()
        {
            if (board == null)
            {
                return;
            }

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    var item = board[row, col];
                    if (item != null)
                    {
                        Destroy(item.prefab);
                    }
                }
            }
        }

        private string CharToPrefabName(char value)
        {
            switch (value)
            {
                case 'Q':
                case 'O':
                    return "Wall02";
                case '-':
                    return "Wall03";
                case 'o':
                    return "Wall04";
                case '#':
                    return "Box";
                case 'T':
                    return "Screw";
                case '\'':
                    return "Ammo";
                case '%':
                    return "Key";
                case 'D':
                    return "Door";
                case 'b':
                    return "Bomb";
                case 'H':
                    return "Ground";
                case '&':
                    return "MirrorOff";
                case 'R':
                    return "Robbo_1";
                case '!':
                    return "CapsuleOff";
                case '@':
                    return "Enemy1_1";
                case '}':
                    return "CannonRight";
                case 'M':
                    return "MagnetLeft";
                case '^':
                    return "EnemyBird_1";
                default:
                    return null;
            }
        }
    }
}