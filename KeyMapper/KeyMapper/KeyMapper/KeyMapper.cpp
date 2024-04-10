#include <Windows.h>
#include <iostream>
#include <thread> // for std::this_thread::sleep_for
#include <chrono> // for std::chrono::milliseconds

bool isG = false;
bool isR = false;
bool isF = false;

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

        if (pkbhs->vkCode == 'R') {
            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                isR = true;
                SendKeyDownEvent('W');
                std::cout << "Detected and remapped 'R' key to 'W'." << std::endl;
                return 1; // Skip original 'R' key press
            }
            else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                isR = false;
                SendKeyUpEvent('W');
                std::cout << "'R' key released." << std::endl;
            }
        }

        if (pkbhs->vkCode == 'W') {
            if (!isR) 
            {
                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                    SendKeyDownEvent('3');
                    std::cout << "Detected and remapped 'W' key to '3'." << std::endl;
                    return 1; // Skip original 'F' key press
                }
                else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                    SendKeyUpEvent('3');
                    std::cout << "'W' key released." << std::endl;
                }
            }
        }

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

        if (pkbhs->vkCode == 'D') {
            if (!isG) 
            {
                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {

                    SendKeyDownEvent('A');
                    std::cout << "Detected and remapped 'D' key to 'A'." << std::endl;
                    return 1; // Skip original 'D' key press

                }
                else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                    SendKeyUpEvent('A');
                    std::cout << "'D' key released." << std::endl;
                }
            }
        }

        if (pkbhs->vkCode == 'F') {
            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                isF = true;
                SendKeyDownEvent('S');
                std::cout << "Detected and remapped 'F' key to 'S'." << std::endl;
                return 1; // Skip original 'F' key press
            }
            else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                isF = false;
                SendKeyUpEvent('S');
                std::cout << "'F' key released." << std::endl;
            }
        }

        if (pkbhs->vkCode == 'K') {
            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                SendKeyDownEvent('1');
                std::cout << "Detected and remapped 'K' key to '1'." << std::endl;
                return 1; // Skip original 'K' key press
            }
            else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                SendKeyUpEvent('1');
                std::cout << "'K' key released." << std::endl;
            }
        }

        if (pkbhs->vkCode == 'I') {
            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                SendKeyDownEvent('2');
                std::cout << "Detected and remapped 'I' key to '2'." << std::endl;
                return 1; // Skip original 'I' key press
            }
            else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                SendKeyUpEvent('2');
                std::cout << "'I' key released." << std::endl;
            }
        }

        if (pkbhs->vkCode == 'Q') {
            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                SendKeyDownEvent('4');
                std::cout << "Detected and remapped 'Q' key to '4'." << std::endl;
                return 1; // Skip original 'I' key press
            }
            else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                SendKeyUpEvent('4');
                std::cout << "'Q' key released." << std::endl;
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
