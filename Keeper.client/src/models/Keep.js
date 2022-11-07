import { Account } from "./Account.js"
import { Profile } from "./Profile.js"

export class Keep {
  constructor(data) {
    this.id = data.id
    this.creatorId = data.creatorId
    this.creator = new Profile(data.creator)
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
    this.name = data.name
    this.description = data.description
    this.img = data.img
    this.views = data.views
    this.kept = data.kept
  }
}