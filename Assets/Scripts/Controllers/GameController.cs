using UnityEngine;
using Robbo.Models;
using UnityEngine.UI;
using System.Linq;

namespace Robbo.Controllers {

    public class GameController : MonoBehaviour
    {
        public LevelController levelController;
        public TextAsset gameDataJson;
        public Text LevelText;
        
        private int currentLevel = 0;
        private int levelCount;
        private GameData gameData;

        void Start()
        {
            gameData = JsonUtility.FromJson<GameData>(gameDataJson.text);
            levelCount = gameData.levels.Count();
            levelController.initLevel(gameData.levels[currentLevel]);

            UpdateLevelText();
            // var my_text = GameObject.Find("LevelTxt").GetComponent<Text>();
        }

        void Update()
        {
          
        }

        public void PrevLevel()
        {
            if (currentLevel > 0)
            {
                currentLevel--;
            } else
            {
                currentLevel = levelCount - 1;
            }

            levelController.initLevel(gameData.levels[currentLevel]);
            UpdateLevelText();
        }

        public void NextLevel()
        {
            if (currentLevel < levelCount -1)
            {
                currentLevel++; 
            } else
            {
                currentLevel = 0;
            }

            levelController.initLevel(gameData.levels[currentLevel]);
            UpdateLevelText();
        }

        private void UpdateLevelText()
        {
            LevelText.text = (currentLevel + 1).ToString() + "/" + levelCount.ToString();
        }
    }
}
