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
appium > appium.log
sleep 10
ps -ef|grep appium

## Desired capabilities:
export APPIUM_APPFILE="$PWD/TrashCat_2.0.1_172.20.10.2.ipa"
export APPIUM_URL="http://localhost:4723/"
export APPIUM_DEVICE="Local Device"
export APPIUM_PLATFORM="iOS"
export APPIUM_AUTOMATION="XCUITest"
export APPIUM_XCODEORGID="59ESG8ELF5"
export APPIUM_XCODESIGNID="iPhone Developer"
export UDID="Paste your UDID here"
## Check iproxy:

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
