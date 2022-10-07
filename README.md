# iOS Build with CSharp Tests

This repository shows a few C# tests that use the page object model and AltUnityTester to test the Unity endless runner sample:
https://assetstore.unity.com/packages/essentials/tutorial-projects/endless-runner-sample-game-87901

### Before running the tests on iOS
- in the `ios_tests.sh` script please change the value for `APPIUM_XCODEORGID` with your Team ID (uniquie 10-character string) in Apple dev account
- export `IOS_UDID=<your-device-udid>` then run the script `ios_tests.sh`

### Running the tests on iOS
`./ios_tests.sh`

This script will:

- start the app on your device
- run the tests
- stop the app after the test are done

More info about the required setup and how to run these tests can be found here: https://altom.gitlab.io/altunity/altunitytester/pages/tester-with-appium.html#