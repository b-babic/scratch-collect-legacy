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

  @override
  void onError(DioException err, ErrorInterceptorHandler handler) {}

  // Error handling
  // @override
  // void onError(DioException err, ErrorInterceptorHandler handler) {
  //   switch (err.connectionType.) {
  //     case DioErrorType.connectTimeout:
  //     case DioErrorType.sendTimeout:
  //     case DioErrorType.receiveTimeout:
  //       throw DeadlineExceededException(err.requestOptions);
  //     case DioErrorType.response:
  //       switch (err.response?.statusCode) {
  //         case 400:
  //           throw BadRequestException(err.requestOptions, err.response);
  //         case 401:
  //           throw UnauthorizedException(err.requestOptions);
  //         case 404:
  //           throw NotFoundException(err.requestOptions);
  //         case 409:
  //           throw ConflictException(err.requestOptions);
  //         case 500:
  //           throw InternalServerErrorException(err.requestOptions);
  //       }
  //       break;
  //     case DioErrorType.cancel:
  //       break;
  //     case DioErrorType.other:
  //       throw NoInternetConnectionException(err.requestOptions);
  //   }
}
