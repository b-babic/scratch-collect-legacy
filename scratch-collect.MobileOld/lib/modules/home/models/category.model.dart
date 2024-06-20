class Category {
  int? id;
  String? name;
  String? gradientStart;
  String? gradientStop;

  Category({
    this.id,
    this.name,
    this.gradientStart,
    this.gradientStop,
  });

  Category.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    name = json['name'];
    gradientStart = json['gradientStart'];
    gradientStop = json['gradientStop'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['id'] = id;
    data['name'] = name;
    data['gradientStart'] = gradientStart;
    data['gradientStop'] = gradientStop;

    return data;
  }
}
