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
        public GameObject[] Prefabs;
        public GameObject GenericItem;
        public Sprite[] Sprites;

        private BoardItem[,] board;
        private int keys = 0;
        private int ammo = 0;
        private int screws = 0;
        private int screwsRequired = 0;

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
                        var prefab = InstantiateItem(prefabName, row, col);
                        board[row, col] = new BoardItem(prefab);
                    }
                }
            }
        }

        private GameObject InstantiateItem(string name, int row, int col)
        {
            var prefab = Prefabs.FirstOrDefault(x => x.name == name);
            if (prefab != null)
            {
                return Instantiate(prefab, new Vector3(col, -1 * row, 0), Quaternion.identity);
            } else
            {
                var generic = Instantiate(GenericItem, new Vector3(col, -1 * row, 0), Quaternion.identity);
                var sprite = Sprites.First(x => x.name == name);
                generic.GetComponent<SpriteRenderer>().sprite = sprite;
                return generic;
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
                    return "Mirror";
                case 'R':
                    return "Robbo";
                case '!':
                    return "CapsuleOff";
                case '@':
                    return "Enemy1";
                case '}':
                    return "CannonRight";
                case 'M':
                    return "MagnetLeft";
                case '^':
                    return "EnemyBird";
                default:
                    return null;
            }
        }
    }
}