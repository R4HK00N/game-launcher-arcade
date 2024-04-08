#include <Windows.h>
#include <iostream>

bool isG = false;

void SendKeyEvent(WORD key, DWORD flags) {
    INPUT input;
    input.type = INPUT_KEYBOARD;
    input.ki.wScan = 0;
    input.ki.time = 0;
    input.ki.dwExtraInfo = 0;
    input.ki.wVk = key;
    input.ki.dwFlags = flags;
    SendInput(1, &input, sizeof(INPUT));
}

LRESULT CALLBACK KeyboardProc(int nCode, WPARAM wParam, LPARAM lParam) {
    if (nCode >= 0) {
        KBDLLHOOKSTRUCT* pkbhs = (KBDLLHOOKSTRUCT*)lParam;
        if (pkbhs->vkCode == 'R') {
            SendKeyEvent('W', 0);
            std::cout << "Detected and remapped 'R' key to 'W'." << std::endl;
            return 1; // Skip original 'W' key press
        }

        if (pkbhs->vkCode == 'D' && isG == false) {
            SendKeyEvent('A', 0);
            std::cout << "Detected and remapped 'D' key to 'A'." << std::endl;
            return 1; // Skip original 'W' key press
        }

        if (pkbhs->vkCode == 'F') {
            SendKeyEvent('S', 0);
            std::cout << "Detected and remapped 'F' key to 'S'." << std::endl;
            return 1; // Skip original 'W' key press
        }

        if (pkbhs->vkCode == 'G') {
            SendKeyEvent('D', 0);
            std::cout << "Detected and remapped 'G' key to 'D'." << std::endl;
            isG = true;
            return 1; // Skip original 'W' key press
        }
        else
        {
            isG = false;
        }
    }
    return CallNextHookEx(NULL, nCode, wParam, lParam);
}

int main() {
    HHOOK g_hook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardProc, NULL, 0);

    if (!g_hook) {
        std::cerr << "Failed to install hook!" << std::endl;
        return 1;
    }

    std::cout << "Keyboard hook installed. Press any key to exit." << std::endl;

    MSG msg;
    while (GetMessage(&msg, NULL, 0, 0)) {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    UnhookWindowsHookEx(g_hook);

    return 0;
}
