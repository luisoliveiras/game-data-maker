# Game Data Maker
![GitHub package.json version](https://img.shields.io/github/package-json/v/luisoliveiras/game-data-maker?color=green)

## What is this?
Game Data Maker is a simple implementation of data saving and loading to a binary file. It provides a simple configuration editor, methods for saving, loading and deleting and callbacks on success or failure for each of those methods.

---
## Installation:
##### On Unity 2018.4:
Download this package to your disk.
Open the package manager on _**Window > Package Manager**_ and select the **+** button and click on the **Add package from disk...** option.
- Add the GameDataMaker package.

##### On Unity 2019.1 and above:
Open the project manifest file under the Packages folder and add these lines to the dependencies:
```json
"dependencies": {
    "com.loophouse.game-data-maker":"https://github.com/luisoliveiras/game-data-maker.git",
}

```

##### On Unity 2019.3 and above:
Open the package manager on _**Window > Package Manager**_ and select the **+** button and click on the **Add package from git URL...** option.
- Add the GameDataMaker package from: https://github.com/luisoliveiras/game-data-maker.git

_\* You can also add it from disk if you want, just follow the steps from 2018.4 install guide._

---
## How To Use:
#### Configuration Window
Access the menu _Tools > Game Data Maker_ to open the game Data Maker configuration editor. If no SaveConfig File was created it will create a new one under _Assets > Resources_.

![Config Window](https://raw.githubusercontent.com/luisoliveiras/project-images/master/game-data-maker/open_config_menu.gif)


**Show Logs:** Use the _Show Logs_ checkbox to enable/disable the logs from the Game Data Maker.

**Game Data Items:** The game data items represents a file and path where it will be saved. The _Name_ property used to access it from code. The Path contains a folder (optional), a file name and a extension, and defines where the file will be saved and loaded from.

_\* The CustomPath class uses the Application.persistentDataPath to define the parent folder of the file._

#### Game Data Manager
The GameDataManager is the class used to access the save data and have 3 main methodsfor that:

**Save:** ```void Save<T>(T data, string item) ``` Serializes T to a binary file (_T and its attributes must be serializable_) in the path set for the item (_name of the Game Data Item in the config file_). Invokes OnSaveSuccess when the file is successfully saved, and OnSaveFail when there is a problem.

**Load:** ```T Load<T>(string item) ``` Deserializes the file from the path set for the item. Invokes OnLoadSuccess when the file is successfully loaded and OnLoadFail when there is a problem loading the file.

**Delete:**  ```void Delete(string item) ``` Deletes the file from the path set for the item. Invokes OnDeleteSuccess when it deletes the file and OnDeleteFail when it is unable to delete it.

---
## Samples:
#### Example 01:

**What:** Contains a basic implementation of save, load and delete, using the _Game Data Maker_ tool.

**How:** Import the _Example 01_ sample from the Package Manager UI. Open the _Example01_ scene inside the folder added to your project's _Assets_ folder and you're ready to go.
