# Echo Arena Stats
A tool to record your stats while you play & also display them through a live-updating stream overlay. 
***
## File Usage/Setup
In the **/Storage** folder, there are different files. 
* `dailyData.json` & `savedData.json` should be left alone. This is how data is stored. 
* `settings.json` holds the configuration for the program. In this file, you input your username, and if on Quest, you change the IP to match that of your headset. 
* `Overlay.txt`,`Stats.txt` & `Daily.txt` are the files that will be displayed in OBS. 

## Data Collection and Display
* **Simple Overlay**
  * Total Games, Wins, Losses, Win Rate
  * Best Used for Streaming/Recording through OBS.   
* **Overall Personal Stats**
  * Accumlative over all matches played with the tool running.
  * Points, Assists, Saves, Stuns
  * Total Games, Wins, Losses, Win Rate
  * Points, Saves, Saves, Stuns averaged per game
* **Daily Personal Stats**
  * Records same stats as above, however just for the day of playing.
 
 ## OBS Usage
 * When using for recording/streaming, add a text element.
 * Check "Read from file"
 * Navigate to your installation folder and select the text file you would like to display. 
 * Choose font/color, and resize/crop to your needs. 


***
If you need assistance with installation/problems occur while using the application, you can contact me through the [Echo Games](https://discord.gg/echogames) discord at **griffin#2050**. 


### Credits: 
Ajedi32 - [API Documentation](https://github.com/Ajedi32/echovr_api_docs)
