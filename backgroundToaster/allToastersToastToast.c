#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <stdbool.h>
#include <shellapi.h>

int main(int argc, char **argv){

    bool ret;
    NOTIFYICONDATAA nid = {0};

    if (argc < 3){
        puts("Needs at least 2 args!");
        return EXIT_FAILURE;
    }

	//MessageBox(NULL,argv[2],argv[1], MB_OK | MB_ICONINFORMATION);
   
    nid.cbSize = sizeof(NOTIFYICONDATAA);
    nid.hWnd = GetConsoleWindow();
    nid.uID = 1; 
    nid.uFlags =  NIF_MESSAGE | NIF_ICON | NIF_INFO;
    nid.uCallbackMessage = WM_USER + 1;
    nid.hIcon = LoadIcon(NULL, IDI_INFORMATION);
    
    nid.dwInfoFlags = NIIF_INFO;
    strncpy(nid.szInfoTitle, argv[1], sizeof(nid.szInfoTitle) - 1);
    strncpy(nid.szInfo, argv[2], sizeof(nid.szInfo) - 1);
    
    ret = Shell_NotifyIconA(NIM_ADD, &nid);
    if (ret == false){
        printf("ADD Error code: %lu (0x%08lX)\n", GetLastError(), GetLastError());
        return EXIT_FAILURE;
    }

    Shell_NotifyIconA(NIM_DELETE, &nid);
    if (ret == false){
        printf("DEL Error code: %lu (0x%08lX)\n", GetLastError(), GetLastError());
        return EXIT_FAILURE;
    }
    


	return EXIT_SUCCESS;    
}
