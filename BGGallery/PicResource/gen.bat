@echo off
chcp 65001 > nul
setlocal enabledelayedexpansion

:: 设置目录列表
set "directories=Icon Work Beos"

:: 设置输出文件
set "outputFile=F:\MemoHippo\MemoHippo\PicResource\menu.txt"

:: 删除已存在的输出文件
if exist "%outputFile%" del "%outputFile%"

:: 处理每个目录
for %%d in (%directories%) do (
    set "directory=%%d"

    if not exist "!directory!" (
        echo 目录不存在: !directory!
    ) else (
        pushd "!directory!"

        for %%F in (*) do (
            echo !directory!\%%F>>"%outputFile%"
        )

        popd
    )
)

echo 文件列表已生成并保存到: %outputFile%
pause