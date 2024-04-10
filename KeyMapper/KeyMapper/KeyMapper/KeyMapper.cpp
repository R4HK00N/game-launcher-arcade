#include <Windows.h>
#include <iostream>
#include <thread> // for std::this_thread::sleep_for
#include <chrono> // for std::chrono::milliseconds

bool isG = false;
bool isR = false;
bool isF = false;
bool isD = false;
bool isLShift = false;
bool isZ = false;
bool isSpace = false;
bool isAlt = false;
bool isK = false;

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
                SendKeyUpEvent('W');
                std::cout << "'R' key released." << std::endl;
                isR = false;
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
                SendKeyUpEvent('D');
                std::cout << "'G' key released." << std::endl;
                isG = false;
            }
        }

        if (pkbhs->vkCode == 'D') {
            if (!isG)
            {
                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                    isD = true;
                    SendKeyDownEvent('A');
                    std::cout << "Detected and remapped 'D' key to 'A'." << std::endl;
                    return 1; // Skip original 'D' key press

                }
                else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                    SendKeyUpEvent('A');
                    std::cout << "'D' key released." << std::endl;
                    isD = false;
                }
            }
        }

        if (pkbhs->vkCode == 'A') {
            if (!isD)
            {
                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                    SendKeyDownEvent('6');
                    std::cout << "Detected and remapped 'A' key to '6'." << std::endl;
                    return 1; // Skip original 'D' key press

                }
                else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                    SendKeyUpEvent('6');
                    std::cout << "'A' key released." << std::endl;
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
                SendKeyUpEvent('S');
                std::cout << "'F' key released." << std::endl;
                isF = false;
            }
        }

        if (pkbhs->vkCode == 'S') {
            if (!isF) {
                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                    SendKeyDownEvent('5');
                    std::cout << "Detected and remapped 'S' key to '5'." << std::endl;
                    return 1; // Skip original 'K' key press
                }
                else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                    SendKeyUpEvent('5');
                    std::cout << "'S' key released." << std::endl;
                }
            }
        }

        if (pkbhs->vkCode == 'K') {
            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                isK = true;
                SendKeyDownEvent('1');
                std::cout << "Detected and remapped 'K' key to '1'." << std::endl;
                return 1; // Skip original 'K' key press
            }
            else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                SendKeyUpEvent('1');
                std::cout << "'K' key released." << std::endl;
                isK = false;
            }
        }

        if (pkbhs->vkCode == 'X') {
            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                SendKeyDownEvent('E');
                std::cout << "Detected and remapped 'X' key to 'E'." << std::endl;
                return 1; // Skip original 'X' key press
            }
            else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                SendKeyUpEvent('E');
                std::cout << "'X' key released." << std::endl;
            }
        }

        if (pkbhs->vkCode == 'I') {
            if (!isZ) {
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
        }

        if (pkbhs->vkCode == 'Z') {
            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                isZ = true;
                SendKeyDownEvent('I');
                std::cout << "Detected and remapped 'Z' key to 'I'." << std::endl;
                return 1; // Skip original 'Z' key press
            }
            else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                SendKeyUpEvent('I');
                std::cout << "'Z' key released." << std::endl;
                isZ = false;
            }
        }

        if (pkbhs->vkCode == 'Q') {
            if (!isLShift) {
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

        if (pkbhs->vkCode == '1') {
            if (!isK) {
                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                    SendKeyDownEvent(VK_RETURN);
                    std::cout << "Detected and remapped '1' key to 'ENTER'." << std::endl;
                    return 1; // Skip original '1' key press
                }
                else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                    SendKeyUpEvent(VK_RETURN);
                    std::cout << "'1' key released." << std::endl;
                }
            }
        }

        if (pkbhs->vkCode == VK_LSHIFT) {
            if (!isSpace){
                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                    isLShift = true;
                    SendKeyDownEvent('Q');
                    std::cout << "Detected and remapped 'LSHIFT' key to 'Q'." << std::endl;
                    return 1; // Skip original 'I' key press
                }
                else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                    SendKeyUpEvent('Q');
                    std::cout << "'LSHIFT' key released." << std::endl;
                    isLShift = false;
                }
            }
        }

        if (pkbhs->vkCode == VK_SPACE) {
            if (!isAlt) {
                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                    isSpace = true;
                    SendKeyDownEvent(VK_LSHIFT);
                    std::cout << "Detected and remapped 'SPACE' key to 'LSHIFT'." << std::endl;
                    return 1; // Skip original 'I' key press
                }
                else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                    SendKeyUpEvent(VK_LSHIFT);
                    std::cout << "'Space' key released." << std::endl;
                    isSpace = false;
                }
            }
        }

        if (pkbhs->vkCode == VK_LMENU) {
            if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) {
                isAlt = true;
                SendKeyDownEvent(VK_SPACE);
                std::cout << "Detected and remapped 'L-ALT' key to 'SPACE'." << std::endl;
                return 1; // Skip original 'I' key press
            }
            else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) {
                SendKeyUpEvent(VK_SPACE);
                std::cout << "'L-ALT' key released." << std::endl;
                isAlt = false;
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
