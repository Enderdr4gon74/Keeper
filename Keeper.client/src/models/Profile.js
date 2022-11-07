export class Profile {
  constructor(data) {
    this.name = data.name
    this.picture = data.picture
    this.coverImg = data.coverImg
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
    this.id = data.id
  }
}