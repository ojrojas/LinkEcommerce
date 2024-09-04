export interface PaginationResponse<T> {
  paginatedItems: PaginatedItems<T>
  correlationId: string;
}

export interface PaginatedItems<T> {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: T;
}
