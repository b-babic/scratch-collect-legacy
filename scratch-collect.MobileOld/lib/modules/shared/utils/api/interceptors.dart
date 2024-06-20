import 'package:dio/dio.dart';
import 'package:IB210370/modules/auth/services/auth.service.dart';

class AppInterceptors extends Interceptor {
  final Dio dio;

  AppInterceptors(this.dio);

  // Autorization handlers
  @override
  void onRequest(
      RequestOptions options, RequestInterceptorHandler handler) async {
    var user = await AuthService().getPersistedUser();
    var token = user.token;

    if (token != null) {
      options.headers['Authorization'] = 'Bearer $token';
    }

    return handler.next(options);
  }
}
