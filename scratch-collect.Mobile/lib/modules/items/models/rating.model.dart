class Rating {
  int? id;
  double? rateCount;
  String? ratedOn;

  Rating({
    this.id,
    this.rateCount,
    this.ratedOn,
  });

  Rating.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    rateCount = json['rateCount'];
    ratedOn = json['ratedOn'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['id'] = id;
    data['rateCount'] = rateCount;
    data['ratedOn'] = ratedOn;

    return data;
  }
}
