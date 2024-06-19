import 'package:ib210370_desktop/config.dart';

class ConfigurationManager {
  static final ConfigurationManager _instance =
      ConfigurationManager._internal();
  late AppConfig _appConfig;

  factory ConfigurationManager() {
    return _instance;
  }

  ConfigurationManager._internal();

  void loadConfig(String flavor) {
    _appConfig = AppConfig.fromEnvironment(flavor);
  }

  AppConfig get config => _appConfig;
}
