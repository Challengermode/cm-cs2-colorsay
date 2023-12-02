# Challengermode CS2 Color Say

Color Say is a simple but useful plugin for CS2 based on the awesome CounterStrikeSharp by roflmuffin. 

Color your message by using following placeholders using the server console command ```csay``` or ```colorsay```

*Colors*
```
{default}
{white} 
{darkred}
{lightpurple}
{green}
{lightgreen}
{slimegreen}
{red} 
{grey} 
{yellow}
{invisible}
{lightblue}
{blue}
{purple} 
{pink}
{fadedred}
{gold}
```

*Examples*
```
csay "{lightgreen}ADMIN:{blue} Blue text here {default} Default colored text here"
```

Feel free to contribute and maintain it. It is intended to be light weight.

# Bump CCS version
```dotnet add package CounterStrikeSharp.API -v x.x.xx```

# Build
```dotnet build```

# Install on server
Copy .dll file from ```/bin/debug/net7.0``` and place it in ```cs2/addons/CounterstrikeSharp/Plugins/ColorSay/ColorSay.dll```

# Credits
* Plugin Framework: CounterStrikeSharp by roflmuffin
* Metamod: https://www.sourcemm.net/
* Challengermode Dev Team


