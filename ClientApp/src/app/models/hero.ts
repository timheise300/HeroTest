import { Brand } from "../models/brand";

export class Hero {
  id: number = 0;
  name: string = "";
  alias?: string = "";
  isActive?: boolean = true;
  brandId: number = 0;
  brand: Brand = new Brand();
}
