#include <Windows.h>
#include <iostream>
#include <thread> // for std::this_thread::sleep_for
#include <chrono> // for std::chrono::milliseconds

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

void SendKeyDownEvent(WORD key) {
    SendKeyEvent(key, 0);
}

void SendKeyUpEvent(WORD key) {
    SendKeyEvent(key, KEYEVENTF_KEYUP);
}

LRESULT CALLBACK KeyboardProc(int nCode, WPARAM wParam, LPARAM lParam) {
    if (nCode >= 0) {
        KBDLLHOOKSTRUCT* pkbhs = (KBDLLHOOKSTRUCT*)lParam;

        if (pkbhs->vkCode == 'G') {
            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                isG = true;
                SendKeyDownEvent('D');
                std::cout << "Detected and remapped 'G' key to 'D'." << std::endl;
                return 1; // Skip original 'G' key press
            }
            else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                isG = false;
                SendKeyUpEvent('D');
                std::cout << "'G' key released." << std::endl;
            }
        }

        if (pkbhs->vkCode == 'R') {
            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                SendKeyDownEvent('W');
                std::cout << "Detected and remapped 'R' key to 'W'." << std::endl;
                return 1; // Skip original 'R' key press
            }
            else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                SendKeyUpEvent('W');
                std::cout << "'R' key released." << std::endl;
            }
        }

        if (pkbhs->vkCode == 'D') {
            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                if (!isG) {
                    SendKeyDownEvent('A');
                    std::cout << "Detected and remapped 'D' key to 'A'." << std::endl;
                    return 1; // Skip original 'D' key press
                }
            }
            else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                SendKeyUpEvent('A');
                std::cout << "'D' key released." << std::endl;
            }
        }

        if (pkbhs->vkCode == 'F') {
            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                SendKeyDownEvent('S');
                std::cout << "Detected and remapped 'F' key to 'S'." << std::endl;
                return 1; // Skip original 'F' key press
            }
            else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                SendKeyUpEvent('S');
                std::cout << "'F' key released." << std::endl;
            }
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

    std::cout << "-----------------------------" << std::endl;
    std::cout << "KeyMapper for Deltion Arcade.\n" << std::endl;
    std::cout << "Made by Nick Schakelaar." << std::endl;
    std::cout << "v1.0" << std::endl;
    std::cout << "-----------------------------" << std::endl;

    MSG msg;
    while (GetMessage(&msg, NULL, 0, 0)) {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    UnhookWindowsHookEx(g_hook);

    return 0;
}
