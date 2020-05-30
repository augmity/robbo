using UnityEngine;

namespace Robbo.Models {

    public class BoardItem
    {
        public GameObject prefab;

        public BoardItem( GameObject prefab)
        {
            this.prefab = prefab;
        }
    }
}