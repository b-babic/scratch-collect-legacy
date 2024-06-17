class AppConfig {
  final String apiUrl;

  AppConfig({required this.apiUrl});

  factory AppConfig.fromEnvironment(String flavor) {
    switch (flavor) {
      case 'dev':
        return AppConfig(apiUrl: 'http://127.0.0.1:5001/api');
      case 'prod':
        return AppConfig(apiUrl: 'http://127.0.0.1:5010/api');
      default:
        throw Exception('Flavor not recognized: $flavor');
    }
  }
}
