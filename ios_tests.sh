#!/bin/bash

#########################################################
#
# Preparing to start Appium
# - UDID is the device ID on which test will run and
#   required parameter on iOS test runs
# - appium - is a wrapper tha calls the latest installed
#   Appium server. Additional parameters can be passed
#   to the server here.
#
#########################################################

echo "UDID set to ${IOS_UDID}"
echo "Starting Appium ..."
appium -U ${IOS_UDID} --log-no-colors --log-timestamp  --command-timeout 180  > appium.log 2>&1 &
sleep 10
ps -ef|grep appium

## Desired capabilities:
export APPIUM_APPFILE="$PWD/TrashCat.ipa"
export APPIUM_URL="http://localhost:4723/wd/hub"
export APPIUM_DEVICE="Local Device"
export APPIUM_PLATFORM="iOS"
export APPIUM_AUTOMATION="XCUITest"
export APPIUM_XCODEORGID="59ESG8ELF5"
export APPIUM_XCODESIGNID="iPhone Developer"

## Check iproxy:
iproxy --version

## Clean local screenshots directory:
rm -rf screenshots

## Run the tests:
echo "Running tests"
cd TestAlttrashCSharp
dotnet restore
dotnet test

echo "Tests done"

echo "---> Killing existing xcode processes:"
killall xcodebuild || true
killall iproxy
