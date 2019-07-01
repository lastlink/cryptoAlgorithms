/*
Shortcuts: https://github.com/Huachao/vscode-restclient
switch environment using shortcut Ctrl+Alt+E(Cmd+Alt+E for macOS)

click the Send Request link above the request, 
or use shortcut Ctrl+Alt+R(Cmd+Alt+R for macOS)

cancel a processing request, use shortcut 
Ctrl+Alt+K(Cmd+Alt+K for macOS), or press F1 
and then select/type Rest Client: Cancel Request

refresh the API response, now you could do it simply 
using shortcut Ctrl+Alt+L(Cmd+Alt+L for macOS), or 
press F1 and then select/type Rest Client: Rerun Last Request to rerun last request

By using shortcut Ctrl+Alt+H(Cmd+Alt+H for macOS), 
or press F1 and then select/type Rest Client: Request History, 
you can view the last 50 request items(method, url and request time) 
in the time reversing order, you can select any request you wish to trigger again

Once you prepared a request as previously, 
use shortcut Ctrl+Alt+C(Cmd+Alt+C for macOS), 
or right-click in the editor and then select 
Generate Code Snippet in the menu, or press F1 
and then select/type Rest Client: Generate Code Snippet
*/

// environment
var settings = {
    'rest-client.environmentVariables': {
        "$shared": {},
        "hashing-c#-dotnetcore.2.x": {
            "protocol": "http",
            "url": "localhost:5000/api",
            "port": "",
        },
        "hashing-php-laravel.2.x": {
            "protocol": "http",
            "url": "localhost:8000/api",
            "port": ""
        }
    }
}