// easy_logging_cpp_demo.cpp: 定义控制台应用程序的入口点。
//

#include "easylogging++.h"

#include <iostream>


INITIALIZE_EASYLOGGINGPP

int main()
{
	LOG(INFO) << "my first info log using default logger";

	//system("pause");

	//getchar();

    return 0;
}

